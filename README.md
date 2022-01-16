# Localiza-Endereco


## About
Localiza Endereço uses [ViaCEP's Web Service](https://viacep.com.br/) to obtain informations about any brazilian address. This repo was developed with .NET 6.0 and uses RestSharp(ver. 107.0.3) and Newtonsoft.Json(ver. 13.0.1), also contains both the service project and a console app project for testing. 





## How to Use
First you have to clone this repository

```
git clone https://github.com/Teuso99/Localiza-Endereco.git
```

After that, you should navigate to the main folder of the project and restore the solution dependencies:

```
cd .\Localiza-Endereco
dotnet restore
```
Finally, you can run the console app:

```
cd .\LocalizaEndereco.Console
dotnet run
```

Then the program will ask for a [CEP (Código de Endereçamento Postal)](https://en.wikipedia.org/wiki/C%c3%b3digo_de_Endere%c3%a7amento_Postal) and will return the matching address.

## License
This project is for study purposes only. Feel free to use.