using IGRUSDB_ASP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRUSDB_ASP.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IgrusDbContext context)
        {
            if (!context.CMembers.Any())
            {
                var CMembers = new CMember[]
                {
                    new CMember
                    {
                        Id = 12191579,
                        Name = "김종하",
                        Email = "12191579@inha.edu",
                        Grade = 3,
                        PhoneNumber = "01066488455",
                        Major = "컴퓨터공학과",  
                        Comment = "TEST GENERATED"
                    },
                    new CMember
                    {
                        Id = 22191579,
                        Name = "테스트",
                        Email = "dumdidum@naver.com",
                        Grade = 2,
                        PhoneNumber = "01015771577",
                        Major = "전자공학과",
                        Comment = "TEST GENERATED"
                    },
                    new CMember
                    {
                        Id = 12191579,
                        Name = "실험용",
                        Email = "jjongha134@naver.com",
                        Grade = 3,
                        PhoneNumber = "01066488455",
                        Major = "경영학과",
                        Comment = "TEST GENERATED"
                    }
                };

                foreach (CMember cMember in CMembers)
                {
                    context.CMembers.Add(cMember);
                }

                context.SaveChanges();
            }

            
        }
    }
}
