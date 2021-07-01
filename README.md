# Localiza-Endereco


## About
This repository is a .NET Console Application that provides an address based on the  [CEP (Brazilian zip code)](https://en.wikipedia.org/wiki/C%c3%b3digo_de_Endere%c3%a7amento_Postal).
The program uses the [Correios' CEP Search](https://buscacepinter.correios.com.br/app/endereco/index.php) to obtain the informations and RestSharp to handle the HTTP Request.


## How to Use
Open the console and navigate to the main folder of the project. Then use command:

```
dotnet restore
```
Then, after restoring all the dependencies, use:

```
dotnet run
```

Then the program will ask for a CEP and after that will return the matching address.

## License
This project is for study purposes only. Feel free to use.
