# HiveSharp
A .NET wrapper to call the api which powers the my.hivehome.com API.

## About

Although it would cool, Hive do not have a public API to control their devices. This library aims to give you access to the internal API used to power the my.hivehome.com site.

<!--## Getting Started-->

## Usage
### Boost the heating
The example below will boost the heating using a product with the id "abc123", for 30 minutes with a target temperature of 20.5C.
	
	var client = new HeatingClient("your@email.co.uk", "yourpassword");
	client.BoostHeating('abc123', 30, 20.5);

### Get the temperature
Gets the temperature from a thermostat device

	client.GetTemperature("<Id of the thermostat device>")

### Get a list of products
Get a list of products associated with your account along with their device Ids.

	client.GetProducts();
