using SQLite;

namespace SoberApp.Code.Models
{
	public class Account
	{
		[AutoIncrement, PrimaryKey]
		public int id {  get; set; }
		public string login { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string name { get; set; }
		public string surnmame { get; set; }
		public DateTime sobrietyDate { get; set; }
		public DateTime sobrietyGoal { get; set; }

		public byte[] avatar {  get; set; }

	}
}