# SDK C#

SDK de integração eRede

# Funcionalidades
Este SDK possui as seguintes funcionalidades:

* Autorização
* Captura
* Consultas
* Cancelamento
* 3DS2
* Zero dollar
* iata
* MCC dinâmico

# Utilizando

## Autorizando uma transação

```csharp
// Configuração da loja
var store = new Store(pv, token, environment);

// Transação que será autorizada
var transaction = new Transaction
{
    amount = 20,
    reference = "pedido123"
}.CreditCard(
    "5448280000000007",
    "235",
    "12",
    "2020",
    "Fulano de tal"
);

// Autoriza a transação
var response = new eRede.eRede(store).create(transaction);

if (response.returnCode == "00")
{
    Console.WriteLine("Transação autorizada com sucesso: " + response.tid);
}
```

Por padrão, a transação é capturada automaticamente; caso seja necessário apenas autorizar a transação, o
método `Transaction::capture()` deverá ser chamado com o parâmetro `false`:

```csharp
// Configuração da loja
var store = new Store(pv, token, environment);

// Transação que será autorizada
var transaction = new Transaction
{
    amount = 20,
    reference = "pedido123"
}.CreditCard(
    "5448280000000007",
    "235",
    "12",
    "2020",
    "Fulano de tal"
).Capture(false);

// Autoriza a transação
var response = new eRede.eRede(store).create(transaction);

if (response.returnCode == "00")
{
    Console.WriteLine("Transação autorizada com sucesso: " + response.tid);
}
```

## Autorizando uma transação IATA

```csharp
// Configuração da loja
var store = new Store(pv, token, environment);

// Transação que será autorizada
var transaction = new Transaction
{
    amount = 20,
    reference = "pedido123"
}.CreditCard(
    "5448280000000007",
    "235",
    "12",
    "2020",
    "Fulano de tal"
).Iata("code123", "250");

// Autoriza a transação
var response = new eRede.eRede(store).create(transaction);

if (response.returnCode == "00")
{
    Console.WriteLine("Transação autorizada com sucesso: " + response.tid);
}
```

## Autorizando uma transação com autenticação

O 3DS é um serviço de autenticação que é obrigatório em transações de débito e opcional em transações de crédito. Saiba
mais através [da documentação](https://www.userede.com.br/desenvolvedores/pt/produto/e-Rede#documentacao-3ds)

```csharp
var store = new Store(pv, token, environment);
var transaction = new Transaction
{
    Amount = 20,
    Reference = "pedido" + new Random().Next(200, 10000),
    ThreeDSecure = new ThreeDSecure
    {
        Embedded = true,
        UserAgent =
            "Mozilla/5.0 (iPad; U; CPU OS 3_2_1 like Mac OS X; en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Mobile/7B405",
        OnFailure = ThreeDSecure.ContinueOnFailure,
        Device = new Device
        {
            ColorDepth = 1,
            DeviceType3ds = "BROWSER",
            JavaEnabled = false,
            ScreenHeight = 1080,
            ScreenWidth = 1920,
            TimeZoneOffset = 3
        }
    },
    Urls = new List<Url>
    {
        new()
        {
            Kind = Url.ThreeDSecureSuccess, url = "https://scommerce.userede.com.br/LojaTeste/Venda/sucesso"
        },
        new()
        {
            Kind = Url.ThreeDSecureFailure, url = "https://scommerce.userede.com.br/LojaTeste/Venda/opz"
        }
    }
}.CreditCard(
    "5448280000000007",
    "235",
    "12",
    "2020",
    "Fulano de tal"
);

var response = new eRede.eRede(store).Create(transaction);
```

Assim que a transação for criada, o cliente precisará ir até a página do banco para autenticar. O código de status `220`
indica que o cliente precisará ser redirecionado:

```csharp
switch (response.ReturnCode)
{
    case "201":
        Console.WriteLine("A autenticação não é necessária");
        break;
    case "220":
        Console.WriteLine($"URL de redirecionamento enviada: {response.ThreeDSecure.Url}");
        break;
    default:
        Console.WriteLine(
            $"Foi retornado o código {response.ReturnCode} com a seguinte mensagem: '{response.ReturnMessage}");
        break;
}
```

Os códigos de [Retorno 3DS](https://www.userede.com.br/desenvolvedores/pt/produto/e-Rede#documentacao-ret3ds) também
estão disponíveis na documentação.


