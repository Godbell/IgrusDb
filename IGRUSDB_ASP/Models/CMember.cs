using System.Collections.Generic;

namespace IGRUSDB_ASP.Models
{
    public class CMember
    {
        /// <summary>
        /// 학번
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 주전공
        /// </summary>
        public string Major { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 이메일 주소
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 학년
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 비고
        /// </summary>
        public string Comment { get; set; }
    }
}
