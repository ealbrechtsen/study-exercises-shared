namespace surfs_up_api.Models
{
    public class CustomerRepository
    {
        private List<Customer> _customers; // Liste til at holde kunderne i hukommelsen

        public CustomerRepository()
        {
            _customers = new List<Customer>(); // Initialiserer den interne liste
        }

        // Tilføjer en ny kunde til listen
        public void AddCustomer(Customer customer)
        {
            // Tildeler et unikt CustomerId til hver ny kunde (auto-increment)
            customer.CustomerId = _customers.Count > 0 ? _customers.Max(c => c.CustomerId) + 1 : 1;
            _customers.Add(customer);
        }

        // Henter en kunde baseret på CustomerId
        public Customer GetCustomerById(int customerId)
        {
            return _customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        // Henter alle kunder
        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        // Opdaterer eksisterende kundeoplysninger
        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = GetCustomerById(customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Address = customer.Address;
                existingCustomer.ZipCode = customer.ZipCode;
                existingCustomer.City = customer.City;
            }
        }

        // Sletter en kunde baseret på CustomerId
        public void DeleteCustomer(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }
}



