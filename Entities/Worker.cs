using ExercicioEnum.Entities.Enums;

namespace ExercicioEnum.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();


        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            List<HourContract> contractsRelatedToSearch = Contracts.FindAll(x => x.Date.Month == month && x.Date.Year == year);

            double valueTotalOfContracts = BaseSalary;

            foreach (var contract in contractsRelatedToSearch)
            {
                valueTotalOfContracts += contract.TotalValue();
            }

            return valueTotalOfContracts;
        }
    }

}