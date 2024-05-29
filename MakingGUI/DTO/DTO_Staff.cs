using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingGUI.DTO
{
    public class DTO_Staff
    {
        private int _id;
        private string _name;
        private DateTime _YoB;
        private bool _gender;
        private string _phoneNumber;
        private float _heSoLuong;
        private string _maPhong;
        private string _maChucVu;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime YoB { get => _YoB; set => _YoB = value; }
        public bool Gender { get => _gender; set => _gender = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public float HeSoLuong { get => _heSoLuong; set => _heSoLuong = value; }
        public string MaPhong { get => _maPhong; set => _maPhong = value; }
        public string MaChucVu { get => _maChucVu; set => _maChucVu = value; }

        public DTO_Staff()
        {

        }

        public DTO_Staff(int id, string name, DateTime YoB, bool gender, string phoneNumber, float heSoLuong, string maPhong, string maChucVu)
        {
            _id = id;
            _name = name;
            _YoB = YoB;
            _gender = gender;
            _phoneNumber = phoneNumber;
            _heSoLuong = heSoLuong;
            _maPhong = maPhong;
            _maChucVu = maChucVu;
        }
    }
}
