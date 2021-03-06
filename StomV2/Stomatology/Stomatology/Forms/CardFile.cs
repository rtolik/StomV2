﻿using System;
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
        #region Variables
        private readonly ISession _sqlSession;

        private bool _imgChanged = false;

        private string _fileName = "";

        private Settings _settings;

        private Patient _selectedPatient;

        private Photo _photo;

        private List<Patient> _patients = new List<Patient>();

        private List<Photo> _photos = new List<Photo>();

        private readonly List<PatientCategory> _categories;

        private readonly List<VisitCategory> _visitCategories;

        private readonly PhoneNumberService _phoneNumberService;

        private readonly PatientService _patientService;

        private readonly PatientCategoryService _patientCategoryService;

        private readonly VisitCategoryService _visitCategoryService;

        private readonly VisitService _visitService;

        private readonly FirmService _firmService;

        private readonly PhotoService _photoService;

        #endregion

        #region Initialization
        public CardFile()
        {
            InitializeComponent();

            InitTheme();

            ISessionFactory mysqlDb = ConfigureMySql();

            _sqlSession = mysqlDb.OpenSession();

            _patientService = new PatientService(_sqlSession);
            
            _patientCategoryService = new PatientCategoryService(_sqlSession);

            _phoneNumberService = new PhoneNumberService(_sqlSession);

            _firmService = new FirmService(_sqlSession);

            _photoService = new PhotoService(_sqlSession);

            _visitCategoryService = new VisitCategoryService(_sqlSession);

            _visitService = new VisitService(_sqlSession);

            _categories = _patientCategoryService.FindAll();

            _visitCategories = _visitCategoryService.FindAll();

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
            DateFrom.Value = GetDefaultLeftDate();
            VisitDateFrom.Value = DateTime.Today.Date.AddYears(-10);

            InitCategory(CategoryComboBox, _categories);
            InitCategory(VisitCategoriyComboBox, _visitCategories);
        }

        private void InitCategory<T>(MetroComboBox comboBox, List<T> categories)
        {
            comboBox.DataSource = categories;

            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Name";
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

        private void InitSelectedPatient()
        {
            IconImageBox.SizeMode = Constants.defaultPictureSizeMode;
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
                PhonesRichTextBox.Text += number.Phone + "\n";

        }

        private void InitSelectedPhoto()
        {
            ImageBox.Image = Image.FromFile(_photo.PhotoPath);
            ImageBox.SizeMode = Constants.defaultPictureSizeMode;
            ImageDescriptionTextBox.Text = _photo.Remark;
        }


        #endregion

        #region LeftMenu

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
            FindPatientPhotos();
        }

        private void VisitsButton_Click(object sender, EventArgs e)
        {
            TabControl.SelectTab(4);
            VisitsGrid.DataSource = FindVisits();
        }

        private void CreateNewPatient(object sender, EventArgs e)
        {
            EnablePersonalInfoTabElements(true);
            _selectedPatient = new Patient();
            InitSelectedPatient();
            TabControl.SelectTab(2);
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (Grid.CurrentRow != null)
                _selectedPatient = (Patient)Grid.CurrentRow.DataBoundItem;
            InitSelectedPatient();
            TabControl.SelectTab(2);
        }

        #endregion

        #region FindPage
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
                    }
                    break;

                case ("Category"):
                    {
                        _patients = _patients.OrderBy(patient => patient.PatientCategory.Id).ToList();
                    }
                    break;

                case ("Name"):
                    {
                        _patients = _patients.OrderBy(patient => patient.FullName).ToList();
                    }
                    break;

                case ("CardNumber"):
                    {
                        _patients = _patients.OrderByDescending(patient => int.Parse(patient.MedicalCard)).ToList();
                    }
                    break;
            }

            RefreshGridData();
        }

        private void ArchiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _patients = _patientService.FindPatientsByArchiveAndFirm(ArchiveCheckBox.Checked, _settings.FirmId);
            SortPatients();
        }

        private void MultipleFinder(object sender, EventArgs e)
        {
            _patients = _patientService.MultipleFinder(CardSearchTextBox.Text, NameSearchTextBox.Text, _settings.FirmId,
                ArchiveCheckBox.Checked);
            SortPatients();
        }

        private void Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Grid.CurrentRow != null)
                _selectedPatient = (Patient)Grid.CurrentRow.DataBoundItem;
        }
        #endregion

        #region PersonalData Page

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EnablePersonalInfoTabElements(true);
            EnablePhotoForm(false);
        }

        private void DiscardBtn_Click(object sender, EventArgs e)
        {
            EnablePersonalInfoTabElements(false);
            InitSelectedPatient();
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
                string iconPath = Resources.InstallPath + "PatientIcon\\" + _selectedPatient.Id + "_" + _fileName;
                pictureBox.Image.Save(iconPath);
                return iconPath;
            }
            return path;
        }

        private void SetPhones()
        {
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            foreach (string line in PhonesRichTextBox.Lines)
                if (line != "\n")
                    phoneNumbers.Add(new PhoneNumber(line.Split('\n')[0], _selectedPatient));
            _selectedPatient.PhoneNumbers = phoneNumbers;
        }

        private void SetSale()
        {
            if (float.TryParse(SaleTextBox.Text, out float sale) || sale > 100)
                _selectedPatient.Sale = sale;
            else
                MetroMessageBox.Show(this, "Поле \"знижка\" введено не коректно! Перевірте значення.");
            _selectedPatient.PatientCategory = (PatientCategory)CategoryComboBox.SelectedItem;
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

        private void IconBtn_Click(object sender, EventArgs e)
        {
            SelectImage(IconImageBox);
        }

        #endregion

        #region PhotoPage

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

            PhotoButton_Click(null, null);
        }

        private void PhotoGrid_RowEnter(object sender, EventArgs e)
        {
            if (PhotoGrid.CurrentRow != null)
            {
                _photo = (Photo)PhotoGrid.CurrentRow.DataBoundItem;
                InitSelectedPhoto();
            }
            else
            {
                _photo = null;
                ImageBox.Image = null;
                ImageDescriptionTextBox.Text = "";
            }
        }

        private void Default_DatePicker_CloseUp(object sender, EventArgs e)
        {
            CheckDateRange(DateFrom, DateTo);

            FindPatientPhotos();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EnablePhotoEditElements(true);
        }

        #endregion

        #region VisitPage

        private List<Visit> FindVisits()
        {
            return _visitService.FindAllByPatientAndRange(_selectedPatient, VisitDateFrom.Value, VisitDateTo.Value, (VisitCategory)VisitCategoriyComboBox.SelectedItem);
        }

        #endregion

        private void TextBoxClean(object sender, EventArgs e)
        {
            MetroTextBox tb = (MetroTextBox) sender;
            tb.Text = "";
        }
               
        private void SelectImage(PictureBox pictureBox)
        {
            _imgChanged = OpenIconDialog.ShowDialog(this) == DialogResult.OK;
            if (_imgChanged)
            {

                pictureBox.SizeMode = Constants.defaultPictureSizeMode;
                pictureBox.Image = Image.FromFile(OpenIconDialog.FileName);
                _fileName = OpenIconDialog.FileName.Split('\\').Last();
            }
        }

        private void CheckDateRange(MetroDateTime left, MetroDateTime right)
        {
            if (left.Value > right.Value)
            {
                MetroMessageBox.Show(this, "Дата початку пошуку має бути меншою ніж дата кінця пошуку!");
                left.Value = DateTo.Value.AddMonths(Constants.MinusMonths);
            }
        }

        private DateTime GetDefaultLeftDate()
        {
            return DateTime.Today.Date.AddMonths(Constants.MinusMonths);
        }

        private void CardFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlSession.Close();
        }
    }
}
