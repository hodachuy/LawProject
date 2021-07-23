using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Enum
{
    public class Status
    {
        /// <summary>
        /// Question status
        /// 1.NoAnswer - chưa trả lời
        /// 2.TransferAdministrativeDivision - chuyển đơn vị hành chính
        /// 3.PendingPublish - chờ xuất bản
        /// 4.Published - đã xuất bản
        /// 5.TransferExpert - chuyển tới chuyên gia
        /// 6.TransferAdmin - chuyển tới quản trị viên
        /// 7.PendingEdit - chờ chỉnh sửa
        /// 8.Edited - đã chỉnh sửa
        /// 9.CancelAnswer - hủy không trả lời
        /// 10.TransferLawyer - chuyển tới luật sư
        /// </summary>
        public enum QuestionAnswer
        {
            NoAnswer = 1,
            TransferAdministrativeDivision = 2,
            PendingPublish = 3,
            Published = 4,
            TransferExpert = 5,
            TransferAdmin = 6,
            PendingEdit = 7,
            Edited = 8,
            CancelAnswer = 9,
            TransferLawyer = 10,
        }

        /// <summary>
        /// Notify status
        /// 1.SHOW_NOT_READ - Hiển thị chưa xem
        /// 2.HIDDEN_NOT_READ - Ẩn chưa xem
        /// 3.SHOW_READED - Hiển thị đã xem
        /// 4.HIDDEN_READED - Ẩn đã xem
        /// </summary>
        public enum Notify
        {
            ShowNotRead = 1,
            HiddenNotRead = 2,
            ShowReaded = 3,
            HiddenReaded = 4
        }

        /// <summary>
        /// User online status
        /// </summary>
        public enum UserOnline
        {
            Online = 201,
            Offline = 202,
            Away = 203,
            Busy = 204
        }

        /// <summary>
        /// Type business service of user
        /// </summary>
        public enum BusinessService
        {
            Free = 301,
            Basic = 302,
            Pro = 303,
            Premium = 304
        }

        /// <summary>
        /// Legal document status
        /// </summary>
        public enum Legal
        {
            CON_HIEU_LUC = 1,
            DA_SUA_DOI = 2,
            HET_HIEU_LUC = 3,
            HET_HIEU_LUC_MOT_PHAN = 4,
            CHUA_AP_DUNG = 5,
            DA_DINH_CHINH_LAI = 6,
            DINH_CHI_HIEU_LUC = 7,
            DINH_CHI_MOT_PHAN_HIEU_LUC = 8,
            KHONG_CON_PHU_HOP = 9,
            DA_BIET = 10,
            CHUA_XAC_DINH = 11
        }
    }
}
