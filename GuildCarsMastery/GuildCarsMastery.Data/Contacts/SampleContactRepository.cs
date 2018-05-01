using GuildCarsMastery.Models.Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Data.Contacts
{
    public class SampleContactRepository
    {
        static List<ContactUs> contacts = new List<ContactUs>
        {
            new ContactUs() { SubmissionId = 1, SubmissionDate = DateTime.Now, ContactName = "Dizzy McFiredface", ContactEmail = "dizzy@doesntsell.org", ContactPhone = "7435644561", ContactMessage = "Please take me back, I love you." },
            new ContactUs() { SubmissionId = 2, SubmissionDate = DateTime.Now.AddHours(-36), ContactName = "Mikee", ContactEmail = "bakonviper@breakfast.org", ContactPhone = "9845263152", ContactMessage = "What times are you open? I need a car." },
            new ContactUs() { SubmissionId = 3, SubmissionDate = DateTime.Now.AddDays(-36), ContactName = "Kristyna", ContactEmail = "kristy@koolkid.com", ContactPhone = "4865441327", ContactMessage = "Do you sell Mustangs?" },
            new ContactUs() { SubmissionId = 4, SubmissionDate = DateTime.Now.AddMonths(-36), ContactName = "Mackenzie", ContactEmail = "magart10@gustavus.edu", ContactPhone = "3213876527", ContactMessage = "1GDE4E1285F534953 is this model still available? Contact me asap." },
            new ContactUs() { SubmissionId = 5, SubmissionDate = DateTime.Now.AddYears(-3), ContactName = "Brandon", ContactEmail = "databasedork@endlessquips.com", ContactPhone = "5165461879", ContactMessage = "2WKPDCFF1RK996857 I would like to harass an employee about this vehicle." }
        };

        public List<ContactUs> GetAll()
        {
            return contacts;
        }
    }
}
