using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || (!email.Contains("@") && !email.Contains(".")) || calculateAge(dateOfBirth) < 21)
            {
                return false;
            }
            
            var client = new ClientRepository().GetById(clientId);
            var user = new User(client, dateOfBirth, email, firstName, lastName);
            
            switch (client.Type)
            {
                case "VeryImportantClient": 
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                    int creditLimit = new UserCreditService().GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit * 2;
                    break;
                case "NormalClient":
                    user.HasCreditLimit = true;
                    user.CreditLimit = new UserCreditService().GetCreditLimit(user.LastName, user.DateOfBirth);
                    if (user.CreditLimit < 500)
                    {
                        return false;
                    }
                    break;
            }
            UserDataAccess.AddUser(user);
            return true;
        }
        
        public int calculateAge(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > now.Date.AddYears(-age)) age--;
            return age;
        }
    }
}
