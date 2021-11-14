using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DB4OApp
{
    public partial class frmMain : Form
    {
        IObjectContainer db = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            db = Db4oEmbedded.OpenFile("Pilot.db");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BttnAdd_Click(object sender, EventArgs e)
        {
            //Step 0: check validation

            //Step 1: New object
            var pilot = new Pilot()
            {
                Id = Guid.NewGuid().ToString(),
                Name = textName.Text,
                Point = double.Parse(textPoint.Text)
            };

            //Step 2: Store DB
            db.Store(pilot);

            //Step 3: Load all data
            LoadAllData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            var filterObj = new Pilot();
            var result = db.QueryByExample(filterObj);
            dgvPilot.DataSource = result;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Close();
        }

        private void dgvPilot_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textID.Text = dgvPilot.Rows[e.RowIndex].Cells[0].Value.ToString();
            textName.Text = dgvPilot.Rows[e.RowIndex].Cells[1].Value.ToString();
            textPoint.Text = dgvPilot.Rows[e.RowIndex].Cells[2].Value.ToString();

        }
        
        private void dgvPilot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textID.Text = dgvPilot.Rows[e.RowIndex].Cells[0].Value.ToString();
            textName.Text = dgvPilot.Rows[e.RowIndex].Cells[1].Value.ToString();
            textPoint.Text = dgvPilot.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filterObj = new Pilot(textID.Text);
            var result =(Pilot) db.QueryByExample(filterObj)[0];
            result.Name = textName.Text;
            result.Point = double.Parse(textPoint.Text);

            db.Store(result);

            LoadAllData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var filterObj = new Pilot(textID.Text);
            var result = (Pilot)db.QueryByExample(filterObj)[0];
            db.Delete(result);

            LoadAllData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Filter by name
            IList<Pilot> result = db.Query<Pilot>(delegate (Pilot pilot)
           {
               return pilot.Name.ToLower().Contains(textName.Text.ToLower());
           });
            dgvPilot.DataSource = result.ToList();
            
        }
    }
}
