namespace Adapter;

public class AddressValidatior1{
    public bool Validate(string city, string postcode){
        Console.WriteLine("--> Validate address from old validator");
        if(string.IsNullOrWhiteSpace(city)){
            Console.WriteLine("City can't be empty");
            return false;
        }

        if(string.IsNullOrWhiteSpace(postcode)){
            Console.WriteLine(" can't be empty");
            return false;
        }

        return true;
    }
}

public interface IAddressValidator{
    bool Validate(string country, string city, string postcode);
}


public class AddressValidatior2 : IAddressValidator{
    private AddressValidatior1 validatior1;
    public AddressValidatior2(AddressValidatior1 av1){
        validatior1 = av1;
    }
    public bool Validate(string country, string city, string postcode){
        Console.WriteLine();
        Console.WriteLine("Validation start...");
        Console.WriteLine($"Your address is * Country: {country}, City: {city}, Postcode: {postcode}");
        Console.WriteLine("Validate address from new validator");
        if(string.IsNullOrWhiteSpace(country)){
            Console.WriteLine("Country can't be empty");
            return false;
        }

        if(!validatior1.Validate(city, postcode)){
            return false;
        }
        Console.WriteLine($"     {country},{city},{postcode} is a valid address");
        return true;
    }
}

public class Test{
    public static void TestAdapter(){
        var av1 = new AddressValidatior1();
        var addressValidatior = new AddressValidatior2(av1);
        addressValidatior.Validate("NZ", "Auckland", "1010");
        addressValidatior.Validate("", "Miami", "nk01");
        addressValidatior.Validate("UK", "London", "csw2");
        addressValidatior.Validate("JP", "Tokoyo", "");
    }
}