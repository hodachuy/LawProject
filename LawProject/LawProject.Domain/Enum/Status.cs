using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Enum
{
    public class Status
    {
        /// <summary>
        /// Question status
        /// </summary>
        public enum QuestionAnswer
        {
            NoAnswer = 1, // chưa trả lời
            TransferAdministrativeDivision = 2, //chuyển đơn vị hành chính
            PendingPublish = 3,
            Published = 4,
            TransferExpert = 5, // chuyển chuyên gia
            TransferAdmin = 6,
            PendingEdit = 7,
            Edited = 8,
            CancelAnswer = 9, // hủy trả lời
            TransferLawyer = 10, // chuyển luật sư
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
            CHUA_XAC_DINH = 10
        }
    }
}
