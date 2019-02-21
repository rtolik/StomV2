using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        private Settings _settings;

        private Patient _selectedPatient;

        private List<Patient> _patients = new List<Patient>();

        private List<Photo> _photos = new List<Photo>();

        private readonly List<PatientCategory> _categories;

        private readonly PhoneNumberService _phoneNumberService;

        private readonly PatientService _patientService;

        private readonly PatientCategoryService _patientCategoryService;

        public CardFile()
        {
            InitializeComponent();

            InitTheme();

            ISessionFactory mysqlDb = ConfigureMySql();

            _patientService = new PatientService(mysqlDb);
            
            _patientCategoryService = new PatientCategoryService(mysqlDb);

            _phoneNumberService = new PhoneNumberService(mysqlDb);

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
        }

        private void PhotoButton_Click(object sender, EventArgs e)
        {
            
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
            foreach (PhoneNumber number in _selectedPatient.PhoneNumbers)
                PhonesRichTextBox.Text += number.Phone+"\n";

        }
    }
}
