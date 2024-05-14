# Banking App Console

 - in c#

emailObj.User["password"]

emailObj.User is a dictionary of <string, string>

it has id,full_name,email,password,cnic,balance,card_number,expiry,cvc in it

I want to access it like emailObj.User.Password

how to map it to


Class User {
	
		public int id { get; set; }
		public int full_name { get; set; }
		public int email { get; set; }
		public int password { get; set; }
		public int cnic { get; set; }
		public int balance { get; set; }
		public int card_number { get; set; }
		public int expiry { get; set; }
		public int cvc { get; set; }

}

 - prop of Errors in interface

 - modify writeData function to accept class instead of dictionary
	- 
	- 
	- 


/* var user = new User
            {
                Fullname = "Fullname",
                Email = "Email",
                Password = "Password",
                Cnic = "Cnic",
                Balance = "0",
                Card = Global.GenerateNumber(16),
                Expiry = Global.GenerateNumber(2),
                Cvc = Global.GenerateNumber(3),
            };

            return result.Count == 0 ? null : user;*/


- Remove Extra Namespace from every file




 var user = new User
            {
                Id = "YBBR4h",
                Fullname = "Noman Shoukat",
                Email = "nomanaadma@gmail.com",
                Password = "Super123",
                Cnic = "4230148518495",
                Balance = "1200",
                Card = "7412844963938986",
                Expiry = "15",
                Cvc = "123",
            };

            new Dashboard(user, this);


            return;


