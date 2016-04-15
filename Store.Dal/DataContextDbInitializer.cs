
using System.Data.Entity;

namespace Store.Dal
{
    //DropCreateDatabaseAlways<DataContext>
    //DropCreateDatabaseIfModelChanges<DataContext>

    public class DataContextDbInitializer: DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.SaveChanges();
        }
    }
}
