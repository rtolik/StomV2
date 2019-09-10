using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using NHibernate;
using NHibernate.Cfg;
using Stomatology.Models;
using Stomatology.Properties;
using Stomatology.Services;
using Stomatology.Utils;
using Settings = Stomatology.Utils.Settings;

namespace Stomatology.Forms
{
    public partial class CardFile : MetroForm
    {
        private bool _imgChanged = false;

        private string _iconExtension = "";

        private string _fileName = "";

        private Settings _settings;

        private Patient _selectedPatient;

        private Photo _photo;

        private List<Patient> _patients = new List<Patient>();

        private List<Photo> _photos = new List<Photo>();

        private readonly List<PatientCategory> _categories;

        private readonly PhoneNumberService _phoneNumberService;

        private readonly PatientService _patientService;

        private readonly PatientCategoryService _patientCategoryService;

        private readonly FirmService _firmService;

        private readonly PhotoService _photoService;

        public CardFile()
        {
            InitializeComponent();

            InitTheme();

            ISessionFactory mysqlDb = ConfigureMySql();

            _patientService = new PatientService(mysqlDb);
            
            _patientCategoryService = new PatientCategoryService(mysqlDb);

            _phoneNumberService = new PhoneNumberService(mysqlDb);

            _firmService = new FirmService(mysqlDb);

            _photoService = new PhotoService(mysqlDb);

            _categories = _patientCategoryService.FindAll();

            InitComponents();
            
            ArchiveCheckBox.Checked = false;

            ArchiveCheckBox_CheckedChanged(this,null);

            MultipleSort_CheckedChanged(RegistrationDateSort,null);
        }

        
        public static ISessionFactory ConfigureMySql()
        {
            return new Configuration()
                .Configure(Resources.InstallPath + @"Settings\hibernate.cfg.xml")
                .BuildSessionFactory();
        }

       
        private void InitComponents()
        {
            DateFrom.Value = DateTime.Today.Date.AddMonths(-1);

            CategoryComboBox.DataSource = _categories;

            CategoryComboBox.DisplayMember = "Name";
            CategoryComboBox.ValueMember = "Name";
        }

        private void InitTheme()
        {
            StyleManager = metroStyleManager1;

            if (File.Exists(Resources.InstallPath + @"Settings\Settings.xml"))
            {
                _settings = SettingsSerializer.DeserializeSettings();
            }
            else
            {
                _settings = new Settings(0, 0,-1);
                SettingsSerializer.SerializeSettings(_settings);
            }

            metroStyleManager1.Style = (MetroColorStyle)_settings.Style;
            metroStyleManager1.Theme = (MetroThemeStyle)_settings.Theme;
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            RefreshGridData();
            EnablePersonalInfoTabElements(false);
            EnablePhotoForm(false);
        }

        private void PhotoButton_Click(object sender, EventArgs e)
        {
            TabControl.SelectTab(1);
            EnablePersonalInfoTabElements(false);
            EnablePhotoForm(true);
            if (Grid.CurrentRow != null)
                _selectedPatient = (Patient)Grid.CurrentRow.DataBoundItem;
            DateFrom.Value = DateFrom.Value.AddMonths(Constants.MinusMonths);
            FindPatientPhotos();
        }

        private void EnablePhotoForm(bool enabled)
        {
            AddButton.Enabled = enabled;
            EditButton.Enabled = enabled;
            DateFrom.Enabled = enabled;
            DateTo.Enabled = enabled;
            PhotoGrid.Enabled = enabled;
        }

        private void FindPatientPhotos()
        {
            _photos = _photoService.FindAllByPatientIdAndDateRange(_selectedPatient.Id.Value, DateFrom.Value, DateTo.Value);
            RefreshPhotoGridData();
        }

        private void RefreshPhotoGridData()
        {
            PhotoGrid.DataSource = _photos;
            TabControl.SelectTab(1);
        }

        private void ArchiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _patients = _patientService.FindPatientsByArchiveAndFirm(ArchiveCheckBox.Checked, _settings.FirmId);
            SortPatients();
        }

        private void SortPatients()
        {
            if (RegistrationDateSort.Checked)
                MultipleSort_CheckedChanged(RegistrationDateSort, null);
            else if (CategorySort.Checked)
                MultipleSort_CheckedChanged(CategorySort, null);
            else if (NameSort.Checked)
                MultipleSort_CheckedChanged(NameSort, null);
            else
                MultipleSort_CheckedChanged(CardNumberSort, null);
        }

        private void RefreshGridData()
        {
            Grid.DataSource = _patients;
            TabControl.SelectTab(0);
        }

        private void MultipleSort_CheckedChanged(object sender, EventArgs e)
        {
            MetroRadioButton rb = (MetroRadioButton)sender;

            switch (rb.Tag.ToString())
            {
                case ("Registration"):
                {
                    _patients = _patients.OrderByDescending(_patients => _patients.DateOfRegistration).ToList();
                }break;

                case ("Category"):
                {
                    _patients = _patients.OrderBy(patient => patient.PatientCategory.Id).ToList();
                }break;

                case ("Name"):
                {
                    _patients = _patients.OrderBy(patient => patient.FullName).ToList();
                }break;

                case ("CardNumber"):
                {
                    _patients = _patients.OrderByDescending(patient => int.Parse(patient.MedicalCard)).ToList();
                }break;
            }

            RefreshGridData();
        }

        private void TextBoxClean(object sender, EventArgs e)
        {
            MetroTextBox tb = (MetroTextBox) sender;
            tb.Text = "";
        }

        private void MultipleFinder(object sender, EventArgs e)
        {
            _patients = _patientService.MultipleFinder(CardSearchTextBox.Text, NameSearchTextBox.Text, _settings.FirmId,
                ArchiveCheckBox.Checked);
            SortPatients();
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (Grid.CurrentRow != null)
                _selectedPatient = (Patient) Grid.CurrentRow.DataBoundItem;
            InitSelectedPatient();
            TabControl.SelectTab(2);
        }

        private void InitSelectedPatient()
        {
            IconImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            IconImageBox.Image = Image.FromFile(_selectedPatient.IconPath);
            CardTextBox.Text = _selectedPatient.MedicalCard;
            RegistrationDate.Value = _selectedPatient.DateOfRegistration;
            CategoryComboBox.SelectedItem = _selectedPatient.PatientCategory;
            SaleTextBox.Text = _selectedPatient.Sale.ToString();
            AdressTextBox.Text = _selectedPatient.Adress;
            FullNameTextBox.Text = _selectedPatient.FullName;
            RemarkTextBox.Text = _selectedPatient.Remark;
            ContraindicationsRichTextBox.Text = _selectedPatient.Contraindications;
            _selectedPatient = _phoneNumberService.AddPhoneNumbersToOnePatient(_selectedPatient);
            PhonesRichTextBox.Text = "";
            ArchiveCheckBox.Checked = _selectedPatient.IsArchive;
            foreach (PhoneNumber number in _selectedPatient.PhoneNumbers)
                PhonesRichTextBox.Text += number.Phone+"\n";

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EnablePersonalInfoTabElements(true);
            EnablePhotoForm(false);
        }

        private void EnablePersonalInfoTabElements(bool enabled)
        {
            ApplyBtn.Visible = enabled;
            DiscardBtn.Visible = enabled;
            IconBtn.Visible = enabled;
            RegistrationDate.Enabled = enabled;
            CardTextBox.Enabled = enabled;
            CardTextBox.Enabled = enabled;
            SaleTextBox.Enabled = enabled;
            FullNameTextBox.Enabled = enabled;
            RemarkTextBox.Enabled = enabled;
            AdressTextBox.Enabled = enabled;
            CategoryComboBox.Enabled = enabled;
            ContraindicationsRichTextBox.Enabled = enabled;
            PhonesRichTextBox.Enabled = enabled;
            ArchivePatientCheckBox.Enabled = enabled;
        }

        private void DiscardBtn_Click(object sender, EventArgs e)
        {
            EnablePersonalInfoTabElements(false);
            InitSelectedPatient();
        }

        private void IconBtn_Click(object sender, EventArgs e)
        {
            SelectImage(IconImageBox);
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            SetPersonalInfo();
            SetSale();
            SetPhones();
            _selectedPatient.IconPath = SetIcon(IconImageBox, _selectedPatient.IconPath);

            if (_selectedPatient.Id == null)
            {
                _selectedPatient.Firm = _firmService.FindOne(_settings.FirmId);
                _patientService.Save(_selectedPatient);
            }
            else
                _patientService.Update(_selectedPatient);

            EnablePersonalInfoTabElements(false);
        }

        private void SetPersonalInfo()
        {
            _selectedPatient.Adress = AdressTextBox.Text;
            _selectedPatient.Contraindications = ContraindicationsRichTextBox.Text;
            _selectedPatient.Remark = RemarkTextBox.Text;
            _selectedPatient.DateOfRegistration = RegistrationDate.Value;
            _selectedPatient.MedicalCard = CardTextBox.Text;
            _selectedPatient.FullName = FullNameTextBox.Text;
            _selectedPatient.IsArchive = ArchivePatientCheckBox.Checked;
        }

        private string SetIcon(PictureBox pictureBox, string path)
        {
            if (_imgChanged)
            {
                string iconPath = Resources.InstallPath + "PatientIcon\\" + _selectedPatient.Id + "_"+ _fileName;//+ "."+_iconExtension
                pictureBox.Image.Save(iconPath);
                return iconPath;
            }
            return path;
        }

        private void SetPhones()
        {
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            foreach (string line in PhonesRichTextBox.Lines)
                if (line!="\n")
                    phoneNumbers.Add(new PhoneNumber(line.Split('\n')[0],_selectedPatient));
            _selectedPatient.PhoneNumbers = phoneNumbers;
        }   

        private void SetSale()
        {
            if (float.TryParse(SaleTextBox.Text, out float sale))
                _selectedPatient.Sale = sale;
            else
                MetroMessageBox.Show(this, "Поле \"знижка\" введено не коректно! Перевірте значення.");
            _selectedPatient.PatientCategory = (PatientCategory) CategoryComboBox.SelectedItem;
        }

        private void CreateNewPatient(object sender, EventArgs e)
        {
            EnablePersonalInfoTabElements(true);
            _selectedPatient = new Patient();
            InitSelectedPatient();
            TabControl.SelectTab(2);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _photo = new Photo();
            EnablePhotoEditElements(true);
            CleanPhotoEditElements();
        }

        private void SelectPhotoBtn_Click(object sender, EventArgs e)
        {
            SelectImage(ImageBox);
        }

        private void SelectImage(PictureBox pictureBox)
        {
            _imgChanged = OpenIconDialog.ShowDialog(this) == DialogResult.OK;
            if (_imgChanged)
            {

                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = Image.FromFile(OpenIconDialog.FileName);
                _fileName = OpenIconDialog.FileName.Split('\\').Last();
                _iconExtension = OpenIconDialog.FileName.Split('.').Last();

            }
        }

        private void ApplyPhotoBtn_Click(object sender, EventArgs e)
        {
            EnablePhotoEditElements(false);

            _photo.PhotoPath = SetIcon(ImageBox, _photo.PhotoPath);
            _photo.Remark = ImageDescriptionTextBox.Text;

            if (_photo.Id == null)
            {
                _photo.Date = DateTime.Today;
                _photo.Patient = _patientService.FindOne(_selectedPatient.Id.Value);
                _photoService.Save(_photo);
            }
            else
            {
                _photoService.Update(_photo);
            }
            FindPatientPhotos();
        }

        private void EnablePhotoEditElements(bool enabled)
        {
            ImageDescriptionTextBox.Enabled = enabled;
            ApplyPhotoBtn.Visible = enabled;
            DiscardPhotoBtn.Visible = enabled;
            PhotoSelectBtn.Visible = enabled;
        }

        private void CleanPhotoEditElements()
        {
            ImageBox.Image = null;
            ImageDescriptionTextBox.Text = "";
        }

        private void DiscardPhotoBtn_Click(object sender, EventArgs e)
        {
            EnablePhotoEditElements(false);

            PhotoButton_Click(null,null);
        }

        private void InitSelectedPhoto()
        {
            ImageBox.Image = Image.FromFile(_photo.PhotoPath);
            ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ImageDescriptionTextBox.Text = _photo.Remark;
        }

        private void PhotoGrid_RowEnter(object sender, EventArgs e)
        {
            if (PhotoGrid.CurrentRow != null)
            {
                _photo = (Photo)PhotoGrid.CurrentRow.DataBoundItem;
                InitSelectedPhoto();
            }
        }
    }
}
