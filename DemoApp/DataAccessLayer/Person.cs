using System;

namespace DataAccessLayer
{
    public class Person : EntityBase
    {
        private int id;
        private String lastName;
        private String firstName;
        private String email;


        public new int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }




    }
}