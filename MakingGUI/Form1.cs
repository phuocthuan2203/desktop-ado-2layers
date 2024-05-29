using MakingGUI.DAO;
using MakingGUI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakingGUI
{
    public partial class Form1 : Form
    {
        StaffDAO staffDAO = new StaffDAO();
        TenPhongDAO tenPhongDAO = new TenPhongDAO();
        TenChucVuDAO tenChucVuDAO = new TenChucVuDAO();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadAllStaff();
            loadTenPhong();
            loadTenChucVu();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loadAllStaff()
        {
            dgvDanhSachNhanVien.DataSource = staffDAO.getAll();
        }

        private void loadTenPhong()
        {
            cbTenPhong.DataSource = tenPhongDAO.getAll();
            cbTenPhong.DisplayMember = "TenPhong";
            cbTenPhong.ValueMember = "MaPhong";
        }

        private void loadTenChucVu()
        {
            cbTenChucVu.DataSource = tenChucVuDAO.getAll();
            cbTenChucVu.DisplayMember = "TenChucVu";
            cbTenChucVu.ValueMember = "MaChucVu";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_Staff staff = new DTO_Staff();
            staff.Name = txtHoVaTen.Text;
            staff.YoB = dtpNgaySinh.Value;
            staff.Gender = (radNam.Checked == true) ? true : false;
            staff.PhoneNumber = txtSoDT.Text;
            staff.HeSoLuong = float.Parse(txtHeSoLuong.Text);
            staff.MaPhong = cbTenPhong.SelectedValue.ToString();
            staff.MaChucVu = cbTenChucVu.SelectedValue.ToString();

            try
            {
                staffDAO.saveStaff(staff);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_Staff staff = new DTO_Staff();
            staff.Id = int.Parse(txtMaNV.Text);
            staff.Name = txtHoVaTen.Text;
            staff.YoB = dtpNgaySinh.Value;
            staff.Gender = (radNam.Checked == true) ? true : false;
            staff.PhoneNumber = txtSoDT.Text;
            staff.HeSoLuong = float.Parse(txtHeSoLuong.Text);
            staff.MaPhong = cbTenPhong.SelectedValue.ToString();
            staff.MaChucVu = cbTenChucVu.SelectedValue.ToString();

            try
            {
                staffDAO.updateStaff(staff);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void dgvDanhSachNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvDanhSachNhanVien.CurrentRow;
            txtMaNV.Text = currentRow.Cells["MaNV"].Value.ToString();
            txtHoVaTen.Text = currentRow.Cells["HoTen"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(currentRow.Cells["NgaySinh"].Value);
            string gender = currentRow.Cells["GioiTinh"].Value.ToString();
            if(gender == "True")
            {
                radNam.Checked = true;
            } else
            {
                radNu.Checked = false;
            }
            txtSoDT.Text = currentRow.Cells["SoDT"].Value.ToString();
            txtHeSoLuong.Text = currentRow.Cells["HeSoLuong"].Value.ToString();
            cbTenPhong.SelectedValue = currentRow.Cells["MaPhong"].Value.ToString();
            cbTenChucVu.SelectedValue = currentRow.Cells["MaChucVu"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                staffDAO.deleteStaff(int.Parse(txtMaNV.Text));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Xoa khong thanh cong");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
