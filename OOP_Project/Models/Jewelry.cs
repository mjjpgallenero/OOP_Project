using System.Security.Policy;
using GalaSoft.MvvmLight;

namespace OOP_Project
{
    public class Jewelry : ObservableObject
    {
        private string _jewelryId;
        private string _jewelryType;
        private string _jewelryQuality;
        private double _weight;
        private double _crystalWeight;
        private string _description;
        private double _totalValue;

        public Jewelry()
        {
            
        }

        public string[] JewelryQualities = {"10K", "18K", "21K"};

        public string JewelryId
        {
            get { return _jewelryId; }
            set
            {
                _jewelryId = value;
                RaisePropertyChanged(nameof(JewelryId));
            }
        }

        public string JewelryType
        {
            get { return _jewelryType; }
            set
            {
                _jewelryType = value;
                RaisePropertyChanged(nameof(JewelryType));
            }
        }

        public string JewelryQuality
        {
            get { return _jewelryQuality; }
            set
            {
                if (value == "10k" || value == "18k" || value == "21k") _jewelryQuality = value;
                RaisePropertyChanged(nameof(JewelryQuality));
                RaisePropertyChanged(nameof(TotalValue));

            }
        }

        public double Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                _weight = _weight - CrystalWeight;
                RaisePropertyChanged(nameof(Weight));
                RaisePropertyChanged(nameof(TotalValue));

            }
        }

        public double CrystalWeight
        {
            get { return _crystalWeight; }
            set
            {
                _crystalWeight = value;
                RaisePropertyChanged(nameof(CrystalWeight));
                RaisePropertyChanged(nameof(Weight));

            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public double TotalValue
        {
            get
            {
                if (JewelryQuality == "10k") return _totalValue = (Weight * 0.417) * 928.64;
                if (JewelryQuality == "18k") return _totalValue = (Weight * 0.75) * 1670.75;
                if (JewelryQuality == "21k") return _totalValue = (Weight * 0.875) * 1949.21;

                return 0;
            }
            
        }
 
    }

    public enum JewelryTypes
    {
        Ring, Necklace, Bracelet, Earring
    }

}