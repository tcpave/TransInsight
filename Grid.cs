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
using TransportExercise.Database;

namespace TransportExercise
{
    public partial class Grid : Form
    {
        private string connectionString;
        private const string connStrName = "myDb";
        private const string keyColumnMake = "make";
        private const string keyColumnModel = "model";
        private const string keyColumnYear = "year";
        private const string keyColumnLicensePlate = "licenseplate";
        private const string keyColumnColor = "color";

        public Grid()
        {
            InitializeComponent();
            connectionString = Utility.GetConnString(connStrName);
            uc_Vehicle1.SelectByIdRequest += Uc_Vehicle1_SelectByIdRequest;
            uc_Vehicle1.InsertRequest += Uc_Vehicle1_InsertRequest;
        }

        private void Uc_Vehicle1_InsertRequest(object sender, ProcEventArgs e)
        {
            var procName = Utility.GetStProcName(e.ProcKey);

            var db = new DbOperations(connectionString);
            Dictionary<string, object> insertDict = new Dictionary<string, object>();
            insertDict.Add(keyColumnMake, uc_Vehicle1.Make);
            insertDict.Add(keyColumnModel, uc_Vehicle1.Model);
            insertDict.Add(keyColumnYear, uc_Vehicle1.Year);
            insertDict.Add(keyColumnLicensePlate, uc_Vehicle1.LicensePlate);
            insertDict.Add(keyColumnColor, uc_Vehicle1.Color);

            int newRecordId = db.InsertSingle(procName, insertDict);
            uc_Vehicle1.InsertProcResult(newRecordId);
        }

        private void Uc_Vehicle1_SelectByIdRequest(object sender, ProcEventArgs e)
        {
            var procName = Utility.GetStProcName(e.ProcKey);

            var db = new DbOperations(connectionString);
            var table = db.SelectSingleById(procName, e.SelectRequestId);
            uc_Vehicle1.SelectByIdProcResult(table);
        }

    }
}
