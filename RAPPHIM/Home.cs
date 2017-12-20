using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuSinessAccessLayer;
using System.Data.SqlClient;
using System.IO;

namespace RAPPHIM
{
    public partial class Home : Form
    {
        public DataTable dtMDH2 = null;
        public string soghe;

        BALoaiVe lv = new BALoaiVe();
        BATheLoai tl = new BATheLoai();
        BALichChieu lc = new BALichChieu();
        BAPhim p = new BAPhim();
        BAPhongChieu pc = new BAPhongChieu();
        BADichVu dvu = new BADichVu();
        BAHoaDonDichVu hddv = new BAHoaDonDichVu();
        BANhanVien nv = new BANhanVien();
        BAVeBan vb = new BAVeBan();
        DataSet ds = new DataSet();
        MemoryStream ms;
        byte[] arrImage;
        private string txtImage = "";
        private byte[] change()
        {
            FileStream fs;
            fs = new FileStream(txtImage, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

       // Phim phh;

        bool f;
        bool ThemNhanVien;
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Load_LichChieu();
            Load_PhongChieu();
            // LoadDichVu();
            // Load_HoaDonDichVu();
            // LoadGhe();
            //LoadData_Ve();
            Load_TheLoai();
            LoadDataNhanVien();
            LoadDataLoaiVe();
            LoadPhim();

            Image im = Properties.Resources.Logo_Vuong;
            ms = new MemoryStream();
            im.Save(ms, im.RawFormat);
            arrImage = ms.GetBuffer();
            ms.Close();

            loadTrangChu();
        }

        //============================================* PHAN LICH CHIEU *=================================================//

        //============================================* PHAN LICH CHIEU *=================================================//
        public void Load_LichChieu()
        {
            btn_luuLC.Enabled = true;
            btn_suaLC.Enabled = true;
            btn_themLC.Enabled = true;
            btn_xoaLC.Enabled = true;

            txt_malichchieu.Enabled = false;
            cbx_maphim.Enabled = false;
            cbx_maphongchieu.Enabled = false;
            dpt_giochieu.Enabled = false;
            dpt_ngaychieu.Enabled = false;



            ds = lc.LayLichChieu();
            dgv_lichchieu.DataSource = ds.Tables[0];
            // load combox cho Ma phòng chiếu
            ds = pc.LayPhongChieu();
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            for (int i = 0; i < dv.Count; i++)
            {
                cbx_maphongchieu.Items.Add(dv.Table.Rows[i][0]);
            }
            cbx_maphongchieu.SelectedIndex = 0;
            //load combox cho ma phim
            ds =  p.LayPhim();
            DataView dvv = new DataView();
            dvv.Table = ds.Tables[0];
            for (int i = 0; i < dvv.Count; i++)
            {
                cbx_maphim.Items.Add(dvv.Table.Rows[i][0]);
            }
            cbx_maphim.SelectedIndex = 0;


        }
        private void btn_huyLC_Click(object sender, EventArgs e)
        {
            Load_LichChieu();
        }

        private void btn_themLC_Click(object sender, EventArgs e)
        {
            f = true;
            txt_malichchieu.ResetText();
            txt_malichchieu.Enabled = true;
            cbx_maphim.Enabled = true;
            cbx_maphongchieu.Enabled = true;
            dpt_giochieu.Enabled = true;
            dpt_ngaychieu.Enabled = true;

            btn_luuLC.Enabled = true;
            btn_suaLC.Enabled = false;
            btn_xoaLC.Enabled = false;
            btn_huyLC.Enabled = true;
            btn_themLC.Enabled = false;

            txt_malichchieu.Focus();
        }


        private void btn_xoaLC_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgv_lichchieu.CurrentCell.RowIndex;
                //lấy mã khách hàng

                txt_malichchieu.Text = dgv_lichchieu.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    string err = "";
                    bool trangthai = lc.XoaLichChieu(ref err, txt_malichchieu.Text);
                    if (trangthai)
                    {
                        Load_LichChieu();
                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                }
            }
            catch (SqlException)
            {

            }
        }

        private void btn_luuLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_malichchieu.Text == "" || dpt_ngaychieu.Text == "" || dpt_giochieu.Text == "" || cbx_maphongchieu.Text == ""
                       || cbx_maphim.Text == "")
                {
                    MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                }
                else
                {
                    if (f)
                    {
                        string err = "";
                        bool trangthai = lc.ThemLichChieu(ref err, txt_malichchieu.Text, DateTime.Parse(dpt_ngaychieu.Text), dpt_giochieu.Text, cbx_maphongchieu.Text, cbx_maphim.Text);
                        //bool trangthai = ncc.ThemNhaCungCap(ref err, txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text);
                        if (trangthai)
                        {
                            Load_LichChieu();
                            MessageBox.Show("Thêm dữ liệu thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Không thêm được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string err = "";
                        bool trangthai = lc.CapNhatLichChieu(ref err, txt_malichchieu.Text, DateTime.Parse(dpt_ngaychieu.Text), dpt_giochieu.Text, cbx_maphongchieu.Text, cbx_maphim.Text);
                        //bool trangthai = ncc.ThemNhaCungCap(ref err, txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text);
                        if (trangthai)
                        {
                            Load_LichChieu();
                            MessageBox.Show("Sữa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không sữa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException)
            {

            }
        }

        private void btn_suaLC_Click(object sender, EventArgs e)
        {
            f = false;

            btn_luuLC.Enabled = true;
            btn_suaLC.Enabled = false;
            btn_xoaLC.Enabled = false;
            btn_huyLC.Enabled = true;
            btn_themLC.Enabled = false;

            txt_malichchieu.Enabled = false;
            cbx_maphongchieu.Enabled = true;
            cbx_maphim.Enabled = true;
            dpt_giochieu.Enabled = true;
            dpt_ngaychieu.Enabled = true;
            //Lay hang can sua
            int r = dgv_lichchieu.CurrentCell.RowIndex;
            this.txt_malichchieu.Text = dgv_lichchieu.Rows[r].Cells[0].Value.ToString();
            this.dpt_ngaychieu.Text = dgv_lichchieu.Rows[r].Cells[1].Value.ToString();
            this.dpt_giochieu.Text = dgv_lichchieu.Rows[r].Cells[2].Value.ToString();
            this.cbx_maphongchieu.Text = dgv_lichchieu.Rows[r].Cells[3].Value.ToString();
            this.cbx_maphim.Text = dgv_lichchieu.Rows[r].Cells[4].Value.ToString();

            txt_malichchieu.Focus();
        }

        private void dgv_lichchieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv_lichchieu.CurrentCell.RowIndex;
            txt_malichchieu.Text = dgv_lichchieu.Rows[r].Cells[0].Value.ToString();
            dpt_ngaychieu.Text = dgv_lichchieu.Rows[r].Cells[1].Value.ToString();
            dpt_giochieu.Text = dgv_lichchieu.Rows[r].Cells[2].Value.ToString();
            cbx_maphongchieu.Text = dgv_lichchieu.Rows[r].Cells[3].Value.ToString();
            cbx_maphim.Text = dgv_lichchieu.Rows[r].Cells[4].Value.ToString();
        }

        private void btn_timkiemLC_Click(object sender, EventArgs e)
        {

        }


        //============================================* PHAN PHONG CHIEU *========================================================//

        //============================================* PHAN PHONG CHIEU *=======================================================//
        public void Load_PhongChieu()
        {
            btn_luuPC.Enabled = true;
            btn_suaPC.Enabled = true;
            btn_themPC.Enabled = true;
            btn_xoaPC.Enabled = true;

            txt_maphongchieu.Enabled = false;
            txt_socho.Enabled = false;
            txt_soday.Enabled = false;
            txt_maychieu.Enabled = false;
            txt_amthanh.Enabled = false;
            txt_dientich.Enabled = false;
            ck_tinhtrang.Enabled = false;
            txt_thietbikhac.Enabled = false;

            ds = pc.LayPhongChieu();
            dgv_phongchieu.DataSource = ds.Tables[0];


        }
        private void btn_huyPC_Click(object sender, EventArgs e)
        {
            Load_PhongChieu();
        }
        private void btn_themPC_Click(object sender, EventArgs e)
        {
            f = true;
            txt_maphongchieu.ResetText();
            txt_maphongchieu.Enabled = true;
            txt_socho.ResetText();
            txt_socho.Enabled = true;
            txt_soday.ResetText();
            txt_soday.Enabled = true;
            txt_maychieu.ResetText();
            txt_maychieu.Enabled = true;
            txt_amthanh.ResetText();
            txt_amthanh.Enabled = true;
            txt_dientich.ResetText();
            txt_dientich.Enabled = true;
            ck_tinhtrang.Enabled = true;
            txt_thietbikhac.ResetText();
            txt_thietbikhac.Enabled = true;

            btn_luuPC.Enabled = true;
            btn_suaPC.Enabled = false;
            btn_xoaPC.Enabled = false;
            btn_themPC.Enabled = false;
            btn_huyPC.Enabled = true;
            txt_maphongchieu.Focus();

        }

        private void btn_suaPC_Click(object sender, EventArgs e)
        {
            btn_luuPC.Enabled = true;
            btn_suaPC.Enabled = false;
            btn_xoaPC.Enabled = false;
            btn_themPC.Enabled = false;
            btn_huyPC.Enabled = true;

            f = false;
            txt_maphongchieu.Enabled = true;
            txt_socho.Enabled = true;
            txt_soday.Enabled = true;
            txt_maychieu.Enabled = true;
            txt_amthanh.Enabled = true;
            txt_dientich.Enabled = true;
            ck_tinhtrang.Enabled = true;
            txt_thietbikhac.Enabled = true;
            //Lay hang can sua
            int r = dgv_phongchieu.CurrentCell.RowIndex;
            this.txt_maphongchieu.Text = dgv_phongchieu.Rows[r].Cells[0].Value.ToString();
            this.txt_socho.Text = dgv_phongchieu.Rows[r].Cells[1].Value.ToString();
            this.txt_soday.Text = dgv_phongchieu.Rows[r].Cells[2].Value.ToString();
            this.txt_maychieu.Text = dgv_phongchieu.Rows[r].Cells[3].Value.ToString();
            this.txt_amthanh.Text = dgv_phongchieu.Rows[r].Cells[4].Value.ToString();
            this.txt_dientich.Text = dgv_phongchieu.Rows[r].Cells[5].Value.ToString();
            this.ck_tinhtrang.Checked = Boolean.Parse(dgv_phongchieu.Rows[r].Cells[6].Value.ToString());
            this.txt_thietbikhac.Text = dgv_phongchieu.Rows[r].Cells[7].Value.ToString();
        }

        private void btn_xoaPC_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgv_phongchieu.CurrentCell.RowIndex;
                //lấy mã khách hàng

                string MaPhongChieu = dgv_phongchieu.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    string err = "";
                    bool trangthai = pc.XoaPhongChieu(ref err, MaPhongChieu);
                    if (trangthai)
                    {

                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_PhongChieu();
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                }
            }
            catch (SqlException)
            {

            }
        }

        private void btn_luuPC_Click(object sender, EventArgs e)
        {
            bool TinhTrang = Boolean.Parse(ck_tinhtrang.Checked.ToString());
            try
            {
                if (txt_maphongchieu.Text == "" || txt_socho.Text == "" || txt_soday.Text == "" || txt_maychieu.Text == ""
                      || txt_amthanh.Text == "" || txt_dientich.Text == "" || ck_tinhtrang.Text == "" || txt_thietbikhac.Text == "")
                {
                    MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                }
                else
                {
                    if (f)
                    {
                        string err = "";
                        bool trangthai = pc.ThemPhongChieu(ref err, txt_maphongchieu.Text, Int32.Parse(txt_socho.Text), Int32.Parse(txt_soday.Text),
                            txt_maychieu.Text, txt_amthanh.Text, txt_dientich.Text, TinhTrang, txt_thietbikhac.Text);
                        //bool trangthai = ncc.ThemNhaCungCap(ref err, txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text);
                        if (trangthai)
                        {
                            Load_PhongChieu();
                            MessageBox.Show("Thêm dữ liệu thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Không thêm được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string err = "";
                        bool trangthai = pc.CapNhatPhongChieu(ref err, txt_maphongchieu.Text, Int32.Parse(txt_socho.Text), Int32.Parse(txt_soday.Text),
                            txt_maychieu.Text, txt_amthanh.Text, txt_dientich.Text, TinhTrang, txt_thietbikhac.Text);
                        //bool trangthai = ncc.ThemNhaCungCap(ref err, txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text);
                        if (trangthai)
                        {
                            Load_PhongChieu();
                            MessageBox.Show("Đã cập nhật xong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Có thông tin chưa nhập kìa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException)
            {

            }
        }

        private void btn_timkiemPC_Click(object sender, EventArgs e)
        {

        }

        private void dgv_phongchieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv_phongchieu.CurrentCell.RowIndex;
            txt_maphongchieu.Text = dgv_phongchieu.Rows[r].Cells[0].Value.ToString();
            txt_socho.Text = dgv_phongchieu.Rows[r].Cells[1].Value.ToString();
            txt_soday.Text = dgv_phongchieu.Rows[r].Cells[2].Value.ToString();
            txt_maychieu.Text = dgv_phongchieu.Rows[r].Cells[3].Value.ToString();
            txt_amthanh.Text = dgv_phongchieu.Rows[r].Cells[4].Value.ToString();
            txt_dientich.Text = dgv_phongchieu.Rows[r].Cells[5].Value.ToString();
            ck_tinhtrang.Checked = Boolean.Parse(dgv_phongchieu.Rows[r].Cells[6].Value.ToString());
            txt_thietbikhac.Text = dgv_phongchieu.Rows[r].Cells[7].Value.ToString();
        }

        //============================================* PHAN THE LOAI *=================================================//

        //============================================* PHAN THE LOAI *=================================================//
        bool ThemTheLoai;
        public void Load_TheLoai()
        {
            this.txtMaTheLoai.ResetText();
            this.txtTenTheLoai.ResetText();

            btnLuuTheLoai.Enabled = true;
            btnSuaTheLoai.Enabled = true;
            btnThemTheLoai.Enabled = true;
            btnXoaTheLoai.Enabled = true;

            txtMaTheLoai.Enabled = false;
            txtTenTheLoai.Enabled = false;

            ds = tl.LayTheLoai();
            dtgvTheLoai.DataSource = ds.Tables[0];
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            ThemTheLoai = true;
            txtMaTheLoai.ResetText();
            txtMaTheLoai.Enabled = true;
            txtTenTheLoai.ResetText();
            txtTenTheLoai.Enabled = true;

            btnThemTheLoai.Enabled = false;
            btnLuuTheLoai.Enabled = true;
            btnSuaTheLoai.Enabled = false;
            btnXoaTheLoai.Enabled = false;

            txtMaTheLoai.Focus();
        }

        private void btnSuaTheLoai_Click(object sender, EventArgs e)
        {
            ThemTheLoai = false;
            txtMaTheLoai.Enabled = false;
            txtTenTheLoai.Enabled = true;

            //dtgvTheLoai_CellClick(null, null);


            btnThemTheLoai.Enabled = false;
            btnLuuTheLoai.Enabled = true;
            btnSuaTheLoai.Enabled = false;
            btnXoaTheLoai.Enabled = false;
            //Lay hang can sua
            int r = dtgvTheLoai.CurrentCell.RowIndex;
            this.txtMaTheLoai.Text = dtgvTheLoai.Rows[r].Cells[0].Value.ToString();
            this.txtTenTheLoai.Text = dtgvTheLoai.Rows[r].Cells[1].Value.ToString();
        }

        private void btnXoaTheLoai_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dtgvTheLoai.CurrentCell.RowIndex;
                //lấy mã khách hàng

                string MaTheLoai = dtgvTheLoai.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    string err = "";
                    bool trangthai = tl.XoaTheLoai(ref err, MaTheLoai);
                    if (trangthai)
                    {

                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_TheLoai();
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                }
            }
            catch (SqlException)
            {

            }
        }

        private void btnLuuTheLoai_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (ThemTheLoai)
            {
                string err = "";
                try
                {
                    if (txtMaTheLoai.Text == "" || txtTenTheLoai.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        f = tl.ThemTheLoai(ref err, txtMaTheLoai.Text, txtTenTheLoai.Text);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            Load_TheLoai();
                            // Thông báo 
                            MessageBox.Show("Đã thêm xong!");
                        }
                        else
                        {
                            MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!ThemTheLoai)
            {
                string err = "";
                try
                {
                    if (txtTenTheLoai.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        f = tl.CapNhatTheLoai(ref err, txtMaTheLoai.Text, txtTenTheLoai.Text);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            Load_TheLoai();
                            // Thông báo 
                            MessageBox.Show("Đã cập nhật xong!");
                        }
                        else
                        {
                            MessageBox.Show("Chưa cập nhật xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        private void btnTimKiemTheLoai_Click(object sender, EventArgs e)
        {

        }

        private void dtgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtgvTheLoai.CurrentCell.RowIndex;
            txtMaTheLoai.Text = dtgvTheLoai.Rows[r].Cells[0].Value.ToString();
            txtTenTheLoai.Text = dtgvTheLoai.Rows[r].Cells[1].Value.ToString();
            dtgvTheLoai.AutoResizeRows();
            dtgvTheLoai.AutoResizeColumns();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_TheLoai();
        }

        //============================================* PHAN NHAN VIEN *=================================================//

        //============================================* PHAN NHAN VIEN *=================================================//

        void LoadDataNhanVien()
        {
            try
            {
                // Xóa trống các đối tượng trong Panel 
                this.txtMaNhanVien.ResetText();
                this.txtHoTen.ResetText();
                this.NgaySinh.ResetText();
                this.ckbGioiTinh.Checked = true;
                this.txtCMND.Enabled = false;
                this.txtSoDienThoai.Enabled = false;
                this.txtChucVu.Enabled = false;
                this.txtDiaChi.Enabled = false;

                this.txtMaNhanVien.Enabled = false;
                this.txtHoTen.Enabled = false;
                this.NgaySinh.Enabled = false;
                this.ckbGioiTinh.Checked = false;
                this.txtCMND.Enabled = false;
                this.txtSoDienThoai.Enabled = false;
                this.txtChucVu.Enabled = false;
                this.txtDiaChi.Enabled = false;





                // Không cho thao tác trên các nút Lưu / Hủy / Lấy Hình
                this.btnLuu.Enabled = false;
                this.btnLayHinh.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                //this.btnTimKiem.Enabled = true;
                //
                ds = nv.LayNhanVien();
                dtgvNhanVien.DataSource = ds.Tables[0];
                //
                //dtgvNhanVien_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi rồi!!!");
            }
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dtgvNhanVien.CurrentCell.RowIndex;
            //MessageBox.Show(dtgvNhanVien.Rows[r].Cells[1].Value.ToString());
            // Chuyển thông tin lên panel 
            this.txtMaNhanVien.Text =
            dtgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.txtHoTen.Text =
            dtgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.NgaySinh.Text =
            dtgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.ckbGioiTinh.Checked = Boolean.Parse(
            dtgvNhanVien.Rows[r].Cells[3].Value.ToString());
            this.txtCMND.Text =
            dtgvNhanVien.Rows[r].Cells[4].Value.ToString();
            this.txtSoDienThoai.Text =
            dtgvNhanVien.Rows[r].Cells[5].Value.ToString();
            this.HinhNV.Image = (System.Drawing.Image)
            dtgvNhanVien.Rows[r].Cells[6].FormattedValue;
            this.txtChucVu.Text =
            dtgvNhanVien.Rows[r].Cells[7].Value.ToString();
            this.txtDiaChi.Text =
            dtgvNhanVien.Rows[r].Cells[8].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            ThemNhanVien = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtMaNhanVien.ResetText();
            this.txtHoTen.ResetText();
            this.NgaySinh.ResetText();
            this.ckbGioiTinh.Checked = false;
            this.txtCMND.ResetText();
            this.txtSoDienThoai.ResetText();
            this.txtChucVu.ResetText();
            this.txtDiaChi.ResetText();
            this.HinhNV.Image = Properties.Resources.Logo_Vuong;

            //Cấp quyền enable
            this.txtMaNhanVien.Enabled = true;
            this.txtHoTen.Enabled = true;
            this.NgaySinh.Enabled = true;
            this.ckbGioiTinh.Checked = false;
            this.txtCMND.Enabled = true;
            this.txtSoDienThoai.Enabled = true;
            this.txtChucVu.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.HinhNV.Enabled = true;


            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btn_huyNV.Enabled = true;
            this.btnLayHinh.Enabled = true;
            this.btnLuu.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
           // this.btnTimKiem.Enabled = false;

            // Đưa con trỏ đến TextField txtMaKH 
            this.txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            ThemNhanVien = false;

            //Cấp quyền enable
            this.txtMaNhanVien.Enabled = false;
            txtMaNhanVien.Text = "ab";
            this.txtHoTen.Enabled = true;
            this.NgaySinh.Enabled = true;
            this.ckbGioiTinh.Checked = false;
            this.txtCMND.Enabled = true;
            this.txtSoDienThoai.Enabled = true;
            this.txtChucVu.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.HinhNV.Enabled = true;
            dtgvNhanVien_CellClick(null, null);
            this.HinhNV.Image = Properties.Resources.Logo_Vuong;
            // Cho thao tác trên các nút Lưu / Hủy / Panel / Lây hình
            this.btnLuu.Enabled = true;
            this.btn_huyNV.Enabled = true;
            this.btnLayHinh.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            //this./btnTimKiem.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH            
            this.txtMaNhanVien.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dtgvNhanVien.CurrentCell.RowIndex;
                // Lấy MaNhanVien của record hiện hành 
                string strMaNhanVien =
                dtgvNhanVien.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = nv.XoaNhanVien(ref err, strMaNhanVien);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadDataNhanVien();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            // Đóng kết nối 
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (ThemNhanVien)
            {
                string err = "";
                try
                {
                    if (txtHoTen.Text == "" || txtMaNhanVien.Text == "" || NgaySinh.Text == "" || txtDiaChi.Text == ""
                        || txtCMND.Text == "" || txtSoDienThoai.Text == "" || txtChucVu.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        f = nv.ThemNhanVien(ref err, txtMaNhanVien.Text, txtHoTen.Text,
                            DateTime.Parse(NgaySinh.Text), ckbGioiTinh.Checked, txtCMND.Text,
                            txtSoDienThoai.Text, arrImage, txtChucVu.Text, txtDiaChi.Text);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            LoadDataNhanVien();
                            // Thông báo 
                            MessageBox.Show("Đã thêm xong!");
                        }
                        else
                        {
                            MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!ThemNhanVien)
            {
                string err = "";
                try
                {
                    if (txtHoTen.Text == "" || NgaySinh.Text == "" || txtDiaChi.Text == ""
                        || txtCMND.Text == "" || txtSoDienThoai.Text == "" || txtChucVu.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        f = nv.CapNhatNhanVien(ref err, txtMaNhanVien.Text, txtHoTen.Text,
                            DateTime.Parse(NgaySinh.Text), ckbGioiTinh.Checked, txtCMND.Text,
                            txtSoDienThoai.Text, arrImage, txtChucVu.Text, txtDiaChi.Text);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            LoadDataNhanVien();
                            // Thông báo 
                            MessageBox.Show("Đã cập nhật xong!");
                        }
                        else
                        {
                            MessageBox.Show("Chưa cập nhật xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

      
        private void btnLayHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                HinhNV.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms = new MemoryStream();
                txtImage = odlgOpenFile.FileName;
                arrImage = change();
                ms.Close();
            }
        }

        private void btn_huyNV_Click(object sender, EventArgs e)
        {
            this.txtMaNhanVien.ResetText();
            this.txtHoTen.ResetText();
            this.NgaySinh.ResetText();
            this.ckbGioiTinh.Checked = false;
            this.txtCMND.ResetText();
            this.txtSoDienThoai.ResetText();
            this.txtChucVu.ResetText();
            this.txtDiaChi.ResetText();
            this.HinhNV.Refresh();

            this.txtMaNhanVien.Enabled = true;
            this.txtHoTen.Enabled = true;
            this.NgaySinh.Enabled = true;
            this.ckbGioiTinh.Checked = false;
            this.txtCMND.Enabled = true;
            this.txtSoDienThoai.Enabled = true;
            this.txtChucVu.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.HinhNV.Enabled = true;


            this.btnLuu.Enabled = false;
            this.btnLayHinh.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
           // this.btnTimKiem.Enabled = true;
        }


        //============================================* PHAN LOAI VE *=================================================//

        //============================================* PHAN LOAI VE *=================================================//

        bool ThemLoaiVe;
        void LoadDataLoaiVe()
        {
            try
            {
                this.txtMaLoaiVe.Enabled = false;
                this.txtTenLoai.Enabled = false;
                this.txtHangGhe.Enabled = false;
                this.txtNgayBan.Enabled = false;
                this.txtDoiTuong.Enabled = false;
                this.txtGia.Enabled = false;



                // Xóa trống các đối tượng trong Panel 
                this.txtMaLoaiVe.ResetText();
                this.txtTenLoai.ResetText();
                this.txtHangGhe.ResetText();
                this.txtNgayBan.ResetText();
                this.txtDoiTuong.ResetText();
                this.txtGia.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy / Lấy Hình
                this.btnLuuLoaiVe.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThemLoaiVe.Enabled = true;
                this.btnSuaLoaiVe.Enabled = true;
                this.btnXoaLoaiVe.Enabled = true;
                //this.btnTimKiemLoaiVe.Enabled = true;
                //
                ds = lv.LayLoaiVe();
                dtgvLoaiVe.DataSource = ds.Tables[0];
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi rồi!!!");
            }
        }

        private void dtgvLoaiVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dtgvLoaiVe.CurrentCell.RowIndex;
            //MessageBox.Show(dtgvNhanVien.Rows[r].Cells[1].Value.ToString());
            // Chuyển thông tin lên panel 
            this.txtMaLoaiVe.Text =
            dtgvLoaiVe.Rows[r].Cells[0].Value.ToString();
            this.txtTenLoai.Text =
            dtgvLoaiVe.Rows[r].Cells[1].Value.ToString();
            this.txtHangGhe.Text =
            dtgvLoaiVe.Rows[r].Cells[2].Value.ToString();
            this.txtNgayBan.Text =
            dtgvLoaiVe.Rows[r].Cells[3].Value.ToString();
            this.txtDoiTuong.Text =
            dtgvLoaiVe.Rows[r].Cells[4].Value.ToString();
            this.txtGia.Text =
            dtgvLoaiVe.Rows[r].Cells[5].Value.ToString();
        }

        private void btnThemLoaiVe_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            ThemLoaiVe = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtMaLoaiVe.ResetText();
            this.txtTenLoai.ResetText();
            this.txtHangGhe.ResetText();
            this.txtNgayBan.ResetText();
            this.txtDoiTuong.ResetText();
            this.txtGia.ResetText();

            //Cấp quyền enable
            this.txtMaLoaiVe.Enabled = true;
            this.txtTenLoai.Enabled = true;
            this.txtHangGhe.Enabled = true;
            this.txtNgayBan.Enabled = true;
            this.txtDoiTuong.Enabled = true;
            this.txtGia.Enabled = true;


            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuuLoaiVe.Enabled = true;
            this.btnHuyLoaiVe.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThemLoaiVe.Enabled = false;
            this.btnSuaLoaiVe.Enabled = false;
            this.btnXoaLoaiVe.Enabled = false;
            //this.btnTimKiemLoaiVe.Enabled = false;

            // Đưa con trỏ đến TextField txtMaKH 
            this.txtMaLoaiVe.Focus();
        }

        private void btnSuaLoaiVe_Click(object sender, EventArgs e)
        {
            ThemLoaiVe = false;

            //Cấp quyền enable
            this.txtMaLoaiVe.Enabled = false;
            this.txtTenLoai.Enabled = true;
            this.txtHangGhe.Enabled = true;
            this.txtNgayBan.Enabled = true;
            this.txtDoiTuong.Enabled = true;
            this.txtGia.Enabled = true;
            dtgvLoaiVe_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel / Lây hình
            this.btnLuuLoaiVe.Enabled = true;
            this.btnHuyLoaiVe.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThemLoaiVe.Enabled = false;
            this.btnSuaLoaiVe.Enabled = false;
            this.btnXoaLoaiVe.Enabled = false;
            //this.btnTimKiemLoaiVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH            
            this.txtMaNhanVien.Focus();
        }

        private void btnXoaLoaiVe_Click(object sender, EventArgs e)
        {
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dtgvLoaiVe.CurrentCell.RowIndex;
                // Lấy MaNhanVien của record hiện hành 
                string strMaLoaiVe =
                dtgvLoaiVe.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = lv.XoaLoaiVe(ref err, strMaLoaiVe);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadDataLoaiVe();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
        }

        private void btnHuyLoaiVe_Click(object sender, EventArgs e)
        {
            this.txtMaLoaiVe.ResetText();
            this.txtTenLoai.ResetText();
            this.txtHangGhe.ResetText();
            this.txtNgayBan.ResetText();
            this.txtDoiTuong.ResetText();
            this.txtGia.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy / Lấy Hình
            this.btnLuuLoaiVe.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThemLoaiVe.Enabled = true;
            this.btnSuaLoaiVe.Enabled = true;
            this.btnXoaLoaiVe.Enabled = true;
            //this.btnTimKiemLoaiVe.Enabled = true;
        }

        private void btnLuuLoaiVe_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (ThemLoaiVe)
            {
                string err = "";
                try
                {
                    if (txtMaLoaiVe.Text == "" || txtTenLoai.Text == "" || txtHangGhe.Text == "" || txtNgayBan.Text == ""
                        || txtDoiTuong.Text == "" || txtGia.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        f = lv.ThemLoaiVe(ref err, txtMaLoaiVe.Text, txtTenLoai.Text,
                            txtHangGhe.Text, txtNgayBan.Text, txtDoiTuong.Text, float.Parse(txtGia.Text));
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            LoadDataLoaiVe();
                            // Thông báo 
                            MessageBox.Show("Đã thêm xong!");
                        }
                        else
                        {
                            MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!ThemLoaiVe)
            {
                string err = "";
                try
                {
                    if (txtTenLoai.Text == "" || txtHangGhe.Text == "" || txtNgayBan.Text == ""
                        || txtDoiTuong.Text == "" || txtGia.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        f = lv.CapNhatLoaiVe(ref err, txtMaLoaiVe.Text, txtTenLoai.Text,
                            txtHangGhe.Text, txtNgayBan.Text, txtDoiTuong.Text, float.Parse(txtGia.Text));
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            LoadDataLoaiVe();
                            // Thông báo 
                            MessageBox.Show("Đã cập nhật xong!");
                        }
                        else
                        {
                            MessageBox.Show("Chưa cập nhật xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        //============================================* PHAN DANH SACH PHIM *=================================================//

        //============================================* PHAN DANH SACH PHIM *=================================================//
        //BAPhim p = new BAPhim();
        //BATheLoai tl = new BATheLoai();
        bool ThemPhim;

        private void txtNamSanXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        void LoadPhim()
        {
            try
            {
                this.txtMaPhim.Enabled = false;
                this.txtTenPhim.Enabled = false;
                this.txtDaoDien.Enabled = false;
                this.cbMaTheLoai.Enabled = false;
                this.txtDienVien.Enabled = false;
                this.txtNoiDung.Enabled = false;
                this.txtTrailer.Enabled = false;
                this.txtNamSanXuat.Enabled = false;
                this.txtQuocGia.Enabled = false;
                this.txtThoiLuong.Enabled = false;

                // Xóa trống các đối tượng trong Panel 
                this.txtMaPhim.ResetText();
                this.txtTenPhim.ResetText();
                this.txtDaoDien.ResetText();
                this.cbMaTheLoai.ResetText();
                this.txtDienVien.ResetText();
                this.txtNoiDung.ResetText();
                this.txtTrailer.ResetText();
                this.txtNamSanXuat.ResetText();
                this.txtQuocGia.ResetText();
                this.txtThoiLuong.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy / Lấy Hình
                this.btnLuu.Enabled = false;
                this.btnLayHinh.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
                this.btnThemPhim.Enabled = true;
                this.btnSuaPhim.Enabled = true;
                this.btnXoaPhim.Enabled = true;
                //this.btnTimKiemPhim.Enabled = true;
                //
                ds = p.LayPhim();
                dtgvPhim.DataSource = ds.Tables[0];

                //Lay combobox MaTheLoai
                ds = tl.LayTheLoai();
                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                for (int i = 0; i < dv.Count; i++)
                {
                    cbMaTheLoai.Items.Add(dv.Table.Rows[i][0]);
                }
                cbMaTheLoai.SelectedIndex = 0;

                loadTrangChu();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi rồi!!!");
            }
        }

        private void dtgvPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtgvPhim.CurrentCell.RowIndex;
            txtMaPhim.Text =
                dtgvPhim.Rows[r].Cells[0].Value.ToString();
            txtTenPhim.Text =
                dtgvPhim.Rows[r].Cells[1].Value.ToString();
            txtDaoDien.Text =
                dtgvPhim.Rows[r].Cells[2].Value.ToString();
            cbMaTheLoai.Text =
                dtgvPhim.Rows[r].Cells[3].Value.ToString();
            txtDienVien.Text =
                dtgvPhim.Rows[r].Cells[4].Value.ToString();
            txtNoiDung.Text =
                dtgvPhim.Rows[r].Cells[5].Value.ToString();
            //MessageBox.Show();
            if (dtgvPhim.Rows[r].Cells[6].Value.GetType().ToString().Equals("System.DBNull"))
            {
                HinhPhim.Image = Properties.Resources.IMG_20161203_135405;
            }
            else
            {
                HinhPhim.Image = (System.Drawing.Image)
               dtgvPhim.Rows[r].Cells[6].FormattedValue;
            }

            txtTrailer.Text =
                dtgvPhim.Rows[r].Cells[7].Value.ToString();
            txtNamSanXuat.Text =
                dtgvPhim.Rows[r].Cells[8].Value.ToString();
            txtQuocGia.Text =
                dtgvPhim.Rows[r].Cells[9].Value.ToString();
            txtThoiLuong.Text =
                dtgvPhim.Rows[r].Cells[10].Value.ToString();
        }

        private void btnThemPhim_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            ThemPhim = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtMaPhim.ResetText();
            this.txtTenPhim.ResetText();
            this.txtDaoDien.ResetText();
            this.cbMaTheLoai.ResetText();
            this.txtDienVien.ResetText();
            this.txtNoiDung.ResetText();
            this.txtTrailer.ResetText();
            this.txtNamSanXuat.ResetText();
            this.txtQuocGia.ResetText();
            this.txtThoiLuong.ResetText();
            this.HinhPhim.Image = Properties.Resources.Logo_Vuong;
            //Cấp quyền enable
            this.txtMaPhim.Enabled = true;
            this.txtTenPhim.Enabled = true;
            this.txtDaoDien.Enabled = true;
            this.cbMaTheLoai.Enabled = true;
            this.txtDienVien.Enabled = true;
            this.txtNoiDung.Enabled = true;
            this.txtTrailer.Enabled = true;
            this.txtNamSanXuat.Enabled = true;
            this.txtQuocGia.Enabled = true;
            this.txtThoiLuong.Enabled = true;


            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuuPhim.Enabled = true;
            this.btnLayHinhPhim.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThemPhim.Enabled = false;
            this.btnSuaPhim.Enabled = false;
            this.btnXoaPhim.Enabled = false;
            //this.btnTimKiemPhim.Enabled = false;

            // Đưa con trỏ đến TextField txtMaKH 
            this.txtMaPhim.Focus();
        }

        private void btnSuaPhim_Click(object sender, EventArgs e)
        {

            // Kích hoạt biến Sửa 
            ThemPhim = false;

            //Cấp quyền enable
            this.txtMaPhim.Enabled = false;
            this.txtTenPhim.Enabled = true;
            this.txtDaoDien.Enabled = true;
            this.cbMaTheLoai.Enabled = true;
            this.txtDienVien.Enabled = true;
            this.txtNoiDung.Enabled = true;
            this.txtTrailer.Enabled = true;
            this.txtNamSanXuat.Enabled = true;
            this.txtQuocGia.Enabled = true;
            this.txtThoiLuong.Enabled = true;
            dtgvPhim_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel / Lây hình
            this.btnLuuPhim.Enabled = true;
            this.btnHuyPhim.Enabled = true;
            this.btnLayHinhPhim.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThemPhim.Enabled = false;
            this.btnSuaPhim.Enabled = false;
            this.btnXoaPhim.Enabled = false;
            //this.btnTimKiemPhim.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH            
            this.txtTenPhim.Focus();
        }

        private void btnXoaPhim_Click(object sender, EventArgs e)
        {
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dtgvPhim.CurrentCell.RowIndex;
                // Lấy MaNhanVien của record hiện hành 
                string strMaPhim =
                dtgvPhim.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = p.XoaPhim(ref err, strMaPhim);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadPhim();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
        }

        private void btnHuyPhim_Click(object sender, EventArgs e)
        {
            this.txtMaPhim.ResetText();
            this.txtTenPhim.ResetText();
            this.txtDaoDien.ResetText();
            this.cbMaTheLoai.ResetText();
            this.txtDienVien.ResetText();
            this.txtNoiDung.ResetText();
            this.txtTrailer.ResetText();
            this.txtNamSanXuat.ResetText();
            this.txtQuocGia.ResetText();
            this.txtThoiLuong.ResetText();
            // Không cho thao tác trên các nút Lưu / Hủy / Lấy Hình
            this.btnLuu.Enabled = false;
            this.btnLayHinh.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThemPhim.Enabled = true;
            this.btnSuaPhim.Enabled = true;
            this.btnXoaPhim.Enabled = true;
           // this.btnTimKiemPhim.Enabled = true;
        }

        private void btnLuuPhim_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (ThemPhim)
            {
                string err = "";
                try
                {
                    if (txtMaPhim.Text == "" || txtTenPhim.Text == "" || txtDaoDien.Text == "" || cbMaTheLoai.Text == ""
                        || txtDienVien.Text == "" || txtNoiDung.Text == "" || txtTrailer.Text == "" || txtNamSanXuat.Text == ""
                        || txtQuocGia.Text == "" || txtThoiLuong.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        f = p.ThemPhim(ref err, txtMaPhim.Text, txtTenPhim.Text,
                            txtDaoDien.Text, cbMaTheLoai.Text, txtDienVien.Text,
                            txtNoiDung.Text, arrImage, txtTrailer.Text, int.Parse(txtNamSanXuat.Text),
                            txtQuocGia.Text, txtThoiLuong.Text);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            LoadPhim();
                            // Thông báo 
                            MessageBox.Show("Đã thêm xong!");
                        }
                        else
                        {
                            MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!ThemPhim)
            {
                string err = "";
                try
                {
                    if (txtTenPhim.Text == "" || txtDaoDien.Text == "" || cbMaTheLoai.Text == ""
                        || txtDienVien.Text == "" || txtNoiDung.Text == "" || txtTrailer.Text == "" || txtNamSanXuat.Text == ""
                        || txtQuocGia.Text == "" || txtThoiLuong.Text == "")
                    {
                        MessageBox.Show("Có thông tin bạn chưa nhập kìa!");
                    }
                    else
                    {
                        f = p.CapNhatPhim(ref err, txtMaPhim.Text, txtTenPhim.Text,
                               txtDaoDien.Text, cbMaTheLoai.Text, txtDienVien.Text,
                               txtNoiDung.Text, arrImage, txtTrailer.Text, int.Parse(txtNamSanXuat.Text),
                               txtQuocGia.Text, txtThoiLuong.Text);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            LoadPhim();
                            // Thông báo 
                            MessageBox.Show("Đã cập nhật xong!");
                        }
                        else
                        {
                            MessageBox.Show("Chưa cập nhật xong!\n\r" + "Lỗi:" + err);
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        private void btnLayHinhPhim_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                HinhPhim.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms = new MemoryStream();
                txtImage = odlgOpenFile.FileName;
                arrImage = change();
                ms.Close();
            }
        }


        //============================================* HOME *=================================================//

        //============================================* HOME *=================================================//

        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        
        void loadTrangChu()
        {
            ds = p.LayPhim();
            DataTable dt = ds.Tables[0];
            List<DataRow> list = new List<DataRow>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr);
            }

            int so = 0;
            int cot = 0;

            while (so < dt.Rows.Count)
            {

                for (int i = 0; i < 5; i++)
                {

                    PictureBox pic = new PictureBox();
                    Label lbl = new Label();
                    Button btn = new Button();
                    pic.Location = new Point(i * 230 + 20, cot * 230 + 20);
                    pic.Name = ds.Tables[0].Rows[so][0].ToString().Trim();
                    pic.AccessibleName = ds.Tables[0].Rows[so][1].ToString().Trim();
                    pic.BackColor = Color.Azure;
                    pic.Size = new Size(200, 200);
                    pic.Image = byteArrayToImage((Byte[])(ds.Tables[0].Rows[so][6]));
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    lbl.Location = new Point(i * 230 + 35, cot * 230 + 225);
                    lbl.Text = (ds.Tables[0].Rows[so][1]).ToString();
                    pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptb_MouseClick);
                    PanelTrangChu.Controls.Add(pic);
                    PanelTrangChu.Controls.Add(lbl);
                    so++;
                    if (so == dt.Rows.Count)
                        break;

                }
                cot++;
            }
        }

        private void ptb_MouseClick(object sender, EventArgs e)
        {
            List<DataRow> list = new List<DataRow>();
            frmTrailer ftl = new frmTrailer(this);
            PictureBox a = (PictureBox)sender;
            ftl.Maphim = a.Name;
            ftl.Text = a.AccessibleName;
            ftl.ShowDialog();
        }
    }
}
