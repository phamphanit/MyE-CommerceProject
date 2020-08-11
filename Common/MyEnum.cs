using System;
using System.ComponentModel;

namespace FinalProject.Common
{
    public enum LoaiHinh
    {
        HangHoa = 2,
        Loai = 1,
        NhaSanXuat = 3,
        KhachHang = 4

    }   
    public enum Role
    {
        [Description("Guest")]
        Guest = 0,
        [Description("Customer")]
        Customer = 1,
        [Description("Accountant")]
        Accountant = 2,
        [Description("Administrator")]
        Administrator = 3,
        [Description("SuperAmin")]
        SuperAdmin =4,
    }

    public enum OrderStatus
    {
        [Description("Open")]
        Open = 0,
        [Description("Confirmed")]
        Confirmed = 1,
        [Description("Paid")]
        Paid = 2,
        [Description("Done")]
        Done = 3,
        [Description("Cancel")]
        Cancel = 4
    }

    public enum PaymentMethod
    {
        COD,
        CreditCard,
        Tranfer,
        InternetBanking,
        SMSBanking,
        MobileBanking
    }
}
