using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NVQLSV;
namespace qlSVwinform
{
    public partial class Form1 : Form
    {
        // FRONT-END
      
        public Form1()
        {
            InitializeComponent();
            GetCBB(cbClassDtgv);
            cbClassDtgv.Items.Add("All");
            cbClassDtgv.SelectedIndex = cbClassDtgv.Items.Count - 1;
        }
        public void GetCBB(ComboBox cbb)
        {
           if (cbb != null)
            {
                cbb.Items.Clear();
            }
            cbb.Items.AddRange(NVQLSV.QLSV_DT.Instance.GetTenLopHP().Distinct().ToArray());
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            //string LopHP = cbClassDtgv.SelectedItem.ToString();
            //dtgvSV.DataSource = NVQLSV.QLSV_DT.Instance.GetSV_ByLopHP(LopHP);
            dtgvSV.DataSource = NVQLSV.QLSV.Instance.GetAllSV();
        }
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MSSV = txtMSSV.Text;
            string NameSV = txtName.Text;
            bool Gender = rBMale.Checked;
            DateTime BD = Convert.ToDateTime(dtpNS.Value);
            string Address = txtAddress.Text;
            string Phone = txtPhone.Text;
            string LopHP = cbClass.SelectedItem.ToString();
            if (NVQLSV.QLSV_DT.Instance.Add(MSSV, NameSV, Gender,
                BD, Address, Phone, LopHP))
            {
                cbClassDtgv.SelectedIndex = cbClassDtgv.Items.Count - 1;
                LopHP = cbClassDtgv.SelectedItem.ToString();
                dtgvSV.DataSource = NVQLSV.QLSV_DT.Instance.GetSV_ByLopHP(LopHP);
            } else
            {
                MessageBox.Show("Error");
            }
            dtgvSV.DataSource = NVQLSV.QLSV_DT.Instance.DB;
        }
        private void btnUpd_Click(object sender, EventArgs e)
        {
            string MSSV = txtMSSV.Text;
            string NameSV = txtName.Text;
            bool Gender = rBMale.Checked;
            DateTime BD = Convert.ToDateTime(dtpNS.Value);
            string Address = txtAddress.Text;
            string Phone = txtPhone.Text;
            string LopHP = cbClass.SelectedItem.ToString();
            if (NVQLSV.QLSV_DT.Instance.Update(MSSV, NameSV, Gender, BD, Address, Phone, LopHP))
            {
                cbClassDtgv.SelectedIndex = cbClassDtgv.Items.Count - 1;
                LopHP = cbClassDtgv.SelectedItem.ToString();
                dtgvSV.DataSource = NVQLSV.QLSV_DT.Instance.GetSV_ByLopHP(LopHP);
            } else
            {
                MessageBox.Show("Error");
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection data = dtgvSV.SelectedRows;
            List<string> MSSV_del = new List<string>();
            foreach(DataGridViewRow i in data)
            {
                MSSV_del.Add(data[0].Cells["MSSV"].Value.ToString());
            }
            if (NVQLSV.QLSV_DT.Instance.Del(MSSV_del))
            {
                cbClassDtgv.SelectedIndex = cbClassDtgv.Items.Count - 1;
                string Lop = cbClassDtgv.SelectedItem.ToString();
                dtgvSV.DataSource = NVQLSV.QLSV_DT.Instance.GetSV_ByLopHP(Lop);
            } else
            {
                MessageBox.Show("Error");
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {

        }
        private void dtgvSV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection data = dtgvSV.SelectedRows;
            if (data.Count == 1)
            {
                string MSSV = data[0].Cells["MSSV"].Value.ToString();
                DataRow row = NVQLSV.QLSV_DT.Instance.GetSV_ByMSSV(MSSV);
                txtMSSV.Text = row["MSSV"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                dtpNS.Value = Convert.ToDateTime(row["Ngày sinh"].ToString());
                txtAddress.Text = row["Địa chỉ"].ToString();
                txtName.Text = row["Họ và Tên"].ToString();
                if (Convert.ToBoolean(row["Giới tính"].ToString()))
                {
                    rBMale.Checked = true;
                }
                else
                {
                    rBFemale.Checked = true;
                }
                GetCBB(cbClass);
                int index = cbClass.Items.IndexOf(row["Lớp học phần"].ToString());
                cbClass.SelectedIndex = index;
            }
        }
    }
}
