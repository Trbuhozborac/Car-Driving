namespace Zadatak_1.Models
{
    class Car
    {
        #region Properties

        public string Name { get; set; }
        public string Direction { get; set; }

        #endregion

        #region Constructors

        public Car()
        {

        }

        public Car(string name, string direction)
        {
            Name = name;
            Direction = direction;
        }

        #endregion
    }
}
