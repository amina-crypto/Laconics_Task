namespace Laconics_Task.Model
{
    public interface ICustomerRepository
    {
        void Delete(int id);
        IEnumerable<Customer> ListAll();
        void Update(Customer customer);

         void  Add(Customer customer);
            Customer Get(int id);
       
    }
}
