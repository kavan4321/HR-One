
namespace HR_One.ViewModel
{
    public class EmailValidation
    {
        public bool Validation(string email)
        {
            string[] Splits = email.Split('@');
            var first = Splits[0];
            var second = Splits[1];

            if(Splits.Count() != 2)
            {
                return false;
            }
            if(first.Length ==0 || second.Length<3)
            {
                return false;
            }
            return true;
        }
    }
}
