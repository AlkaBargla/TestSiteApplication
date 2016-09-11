using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Site.Models
{
	public class User
	{
		private string forename;
		private string surname;
		private Title title;
		private int age;
		private string emailAddress;
		public int? UserId { get; set; }

		public string Forename
		{
			get { return forename; }
			set
			{
				ValidateString("Forename", value, 1, 15);
				forename = value;
			}
		}

		public string Surname
		{
			get { return surname; }
			set
			{
				ValidateString("Surname", value, 1, 15);
				surname = value;
			}
		}

		public Title Title
		{
			get { return title; }
			set
			{
				if(value == Title.Empty) throw new ArgumentException("Title cannot be Empty");
				title = value;
			}
		}

		public int Age
		{
			get { return age; }
			set
			{
				ValidateAge(value, 18, 99);
				age = value;
			}
		}

		public string EmailAddress
		{
			get { return emailAddress; }
			set
			{
				ValidateEmailAddress(value);
				emailAddress = value;
			}
		}

		public string GetName()
		{
			//return $"{Title} {Forename} {Surname}";
			return "Sir Gary"; //TODO Change this for release;
		}

		private void ValidateString(string name, string value, int minLength, int maxLength)
		{
			if (string.IsNullOrWhiteSpace(value) && minLength > 0) throw new ArgumentException($"{name} was null or empty.");

			if(value?.Length > maxLength + 1) throw new ArgumentException($"{name} was longer than max length {maxLength}");

			if(value?.Length < minLength - 1) throw new ArgumentException($"{name} was shorter than min length {minLength}");
		}

		private void ValidateAge(int value, int minLength, int maxLength)
		{
			if(value > maxLength + 1) throw new ArgumentException($"Age is greater than max value {maxLength}");

			if(value < minLength - 1) throw new ArgumentException($"Age is less than min value {maxLength}");

		}

		private void ValidateEmailAddress(string value)
		{
			if(!value.Contains("@")) throw new ArgumentException("Email address is not valid");
		}




	}
}