using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportExercise.Models;

namespace TransportExercise
{
    public partial class uc_Vehicle : UserControl
    {
        public event EventHandler<ProcEventArgs> InsertRequest;
        public event EventHandler<ProcEventArgs> SelectByIdRequest;

        public const string insertProcKey = "stproc_VehicleInsert";
        public const string selectByIdProcKey = "stproc_VehicleSelectById";
        const string columnKeyId = "id";
        const string columnKeyMake = "make";
        const string columnKeyModel = "model";
        const string columnKeyYear = "year";
        const string columnKeyLicensePlate = "licenseplate";
        const string columnKeyColor = "color";

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }

        public uc_Vehicle()
        {
            InitializeComponent();
        }

        private void uc_Vehicle_Load(object sender, EventArgs e)
        {
            //ResetForm();
            ResetErrorMessages();
            ResetInputsOutputs();

            rdoInsert.Checked = true;
            ShowInsertCommand();
            
            //if (rdoInsert.Checked)
            //{
            //    ShowInsertCommand();
            //}
            //else
            //{
            //    ShowSelectCommand();
            //}
        }

        private void ResetErrorMessages()
        {
            lblRecordError.Text = "";
            lblRecordError.Hide();

            lblModelError.Text = "";
            lblModelError.Hide();

            lblMakeError.Text = "";
            lblMakeError.Hide();

            lblLicensePlateError.Text = "";
            lblLicensePlateError.Hide();

            lblYearError.Text = "";
            lblYearError.Hide();
        }

        private void ResetInputsOutputs()
        {
            dataId.Text = "";
            dataMake.Text = "";
            dataModel.Text = "";
            dataYear.Text = "";
            dataLicensePlate.Text = "";
            dataColor.Text = "";

            txtId.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtYear.Text = "";
            txtLicensePlate.Text = "";
            txtColor.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInputsOutputs();
            ResetErrorMessages();
        }

        private void rdoInsert_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInsert.Checked)
            {
                ShowInsertCommand();
            }
        }

        private void ShowInsertCommand()
        {
            HideSelectCommand();

            btnInsert.Show();
            txtId.Hide();
            txtMake.Show();
            txtModel.Show();
            txtYear.Show();
            txtLicensePlate.Show();
            txtColor.Show();
        }

        private void rdoSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSelect.Checked)
            {
                ShowSelectCommand();
            }
        }

        private void ShowSelectCommand()
        {
            HideInsertCommand();

            btnSelect.Show();
            dataId.Show();
            dataMake.Show();
            dataModel.Show();
            dataYear.Show();
            dataLicensePlate.Show();
            dataColor.Show();

            txtId.Show();
            txtMake.Hide();
            txtModel.Hide();
            txtYear.Hide();
            txtLicensePlate.Hide();
            txtColor.Hide();
        }

        private void HideInsertCommand()
        {
            btnInsert.Hide();
            txtMake.Hide();
            txtModel.Hide();
            txtYear.Hide();
            txtLicensePlate.Hide();
            txtColor.Hide();
        }

        private void HideSelectCommand()
        {
            btnSelect.Hide();
            dataId.Hide();
            dataMake.Hide();
            dataModel.Hide();
            dataYear.Hide();
            dataLicensePlate.Hide();
            dataColor.Hide();
        }

        //private void ResetDataSelection()
        //{
        //    dataId.Text = "";
        //    dataMake.Text = "";
        //    dataModel.Text = "";
        //    dataYear.Text = "";
        //    dataLicensePlate.Text = "";
        //    dataColor.Text = "";
        //}

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (Int32.TryParse(txtId.Text, out id))
            {
                if (id > 0)
                {
                    ResetErrorMessages();
                    ResetInputsOutputs();
                    ProcEventArgs args = new ProcEventArgs();
                    args.ProcKey = selectByIdProcKey;

                    args.SelectRequestId = id;
                    SelectByIdRequest(this, args);
                    txtId.Text = id.ToString();
                    return;
                }
            }

            lblRecordError.Text = "Invalid Format";
            lblRecordError.Show();
        }

        public void SelectByIdProcResult(DataTable dt)
        {
            if (dt == null)
            {
                lblRecordError.Text = "Record Not Found";
                lblRecordError.Show();
                return;
            }

            dataId.Text = dt.Rows[0][columnKeyId].ToString();
            dataMake.Text = dt.Rows[0][columnKeyMake].ToString();
            dataModel.Text = dt.Rows[0][columnKeyModel].ToString();
            dataYear.Text = dt.Rows[0][columnKeyYear].ToString();
            dataLicensePlate.Text = dt.Rows[0][columnKeyLicensePlate].ToString();
            dataColor.Text = dt.Rows[0][columnKeyColor].ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //ResetForm();

            var vehicle = new Vehicle();
            Make = txtMake.Text.Trim();
            Model = txtModel.Text.Trim();
            LicensePlate = txtLicensePlate.Text.Trim();
            Color = txtColor.Text.Trim();

            if (ValidateInsertModel())
            {
                ProcEventArgs args = new ProcEventArgs();
                args.ProcKey = insertProcKey;
                InsertRequest(this, args);
            }
        }

        public void InsertProcResult(int newRecordId)
        {
            if (newRecordId > 0)
            {
                ResetErrorMessages();
                lblRecordError.Text = $"Record inserted with id {newRecordId}";
                lblRecordError.Show();

                dataId.Text = newRecordId.ToString();
                dataMake.Text = txtMake.Text.Trim();
                dataModel.Text = txtModel.Text.Trim();
                dataYear.Text = txtYear.Text.Trim();
                dataLicensePlate.Text = txtLicensePlate.Text.Trim();
                dataColor.Text = txtColor.Text.Trim();

                dataId.Show();
                dataMake.Show();
                dataModel.Show();
                dataYear.Show();
                dataLicensePlate.Show();
                dataColor.Show();

                txtMake.Text = "";
                txtModel.Text = "";
                txtYear.Text = "";
                txtLicensePlate.Text = "";
                txtColor.Text = "";
            }
        }

        private bool ValidateInsertModel()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(Make))
            {
                lblMakeError.Text = "Make is a required field";
                lblMakeError.Show();
                valid = false;
            }

            if (string.IsNullOrEmpty(Model))
            {
                lblModelError.Text = "Model is a required field";
                lblModelError.Show();
                valid = false;
            }

            int year = 0;
            if (Int32.TryParse(txtYear.Text.Trim(), out year))
            {
                if (year > 0)
                {
                    Year = year;
                }
                else
                {
                    lblYearError.Text = "Year cannot be a negative number";
                    lblYearError.Show();
                    valid = false;
                }
            }
            else
            {
                lblYearError.Text = "Year is invalid";
                lblYearError.Show();
                valid = false;
            }

            if (string.IsNullOrEmpty(LicensePlate))
            {
                lblLicensePlateError.Text = "License Plate is a required field";
                lblLicensePlateError.Show();
                valid = false;
            }

            return valid;
        }

    }

  }
