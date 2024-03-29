using System;
using System.Collections.Generic;
using eRede;
using eRede.Service.Error;
using NUnit.Framework;
using Environment = eRede.Environment;

namespace eRedeTests;

public class eRedeTest
{
    private string? _cardCvv;
    private string? _cardHolder;
    private string? _cardNumber;
    private string? _ec;
    private Environment? _environment;
    private DateTime _expiration;
    private string? _token;

    [SetUp]
    public void Setup()
    {
        _ec = System.Environment.GetEnvironmentVariable("EC");
        _token = System.Environment.GetEnvironmentVariable("TOKEN");

        if (_ec is null || _token is null) throw new NullReferenceException("EC e Token devem ser informados");

        _environment = Environment.Sandbox();
        _expiration = DateTime.Today.AddMonths(3);

        _cardNumber = "5448280000000007";
        _cardCvv = "123";
        _cardHolder = "Fulano de tal";
    }

    [Test]
    public void Test3DS2()
    {
        var store = new Store("", "", _environment);
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
                    Language = "BR",
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
            _cardNumber,
            _cardCvv,
            _expiration.Month.ToString(),
            _expiration.Year.ToString(),
            _cardHolder
        );

        var response = new eRede.eRede(store).Create(transaction);

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
    }

    [Test]
    public void TestEcTokenAreRequired()
    {
        var store = new Store("", "", _environment);
        var transaction = new Transaction
        {
            Amount = 20,
            Reference = "pedido" + new Random().Next(200, 10000)
        }.CreditCard(
            _cardNumber,
            _cardCvv,
            _expiration.Month.ToString(),
            _expiration.Year.ToString(),
            _cardHolder
        );

        Assert.Throws<RedeException>(() => new eRede.eRede(store).Create(transaction));
    }

    [Test]
    public void TestCreditCardAuthorization()
    {
        var store = new Store(_ec, _token, _environment);
        var transaction = new Transaction
        {
            Amount = 20,
            Reference = "pedido" + new Random().Next(200, 10000)
        }.CreditCard(
            _cardNumber,
            _cardCvv,
            _expiration.Month.ToString(),
            _expiration.Year.ToString(),
            _cardHolder,
            false
        );

        var response = new eRede.eRede(store).Create(transaction);

        Assert.AreEqual("00", response.ReturnCode);
        Assert.That(response.AuthorizationCode, Is.Not.Empty);
        Assert.That(response.Tid, Is.Not.Empty);
        Assert.That(response.Brand, Is.Not.Null);
        Assert.That(response.Brand.Name, Is.Not.Null);
        Assert.That(response.Brand.ReturnCode, Is.Not.Null);
        Assert.That(response.Brand.ReturnMessage, Is.Not.Null);
    }

    [Test]
    public void TestCreditCardAuthorizationWithCapture()
    {
        var store = new Store(_ec, _token, _environment);
        var transaction = new Transaction
        {
            Amount = 20,
            Reference = "pedido" + new Random().Next(200, 10000)
        }.CreditCard(
            _cardNumber,
            _cardCvv,
            _expiration.Month.ToString(),
            _expiration.Year.ToString(),
            _cardHolder
        );

        var response = new eRede.eRede(store).Create(transaction);

        Assert.AreEqual("00", response.ReturnCode);
        Assert.That(response.AuthorizationCode, Is.Not.Empty);
        Assert.That(response.Tid, Is.Not.Empty);
        Assert.That(response.Brand, Is.Not.Null);
        Assert.That(response.Brand.Name, Is.Not.Null);
        Assert.That(response.Brand.ReturnCode, Is.Not.Null);
        Assert.That(response.Brand.ReturnMessage, Is.Not.Null);
    }

    [Test]
    public void TestCancellation()
    {
        var store = new Store(_ec, _token, _environment);
        var transaction = new Transaction
        {
            Amount = 20,
            Reference = "pedido" + new Random().Next(200, 10000)
        }.CreditCard(
            _cardNumber,
            _cardCvv,
            _expiration.Month.ToString(),
            _expiration.Year.ToString(),
            _cardHolder
        );

        var eRede = new eRede.eRede(store);
        var response = eRede.Create(transaction);

        var cancellation = eRede.Cancel(transaction, response.Tid);

        Assert.That(cancellation.RefundId, Is.Not.Empty);
    }

    [Test]
    public void TestCapture()
    {
        var store = new Store(_ec, _token, _environment);
        var transaction = new Transaction
        {
            Amount = 20,
            Reference = "pedido" + new Random().Next(200, 10000)
        }.CreditCard(
            _cardNumber,
            _cardCvv,
            _expiration.Month.ToString(),
            _expiration.Year.ToString(),
            _cardHolder,
            false
        );

        var eRede = new eRede.eRede(store);
        var response = eRede.Create(transaction);

        try
        {
            var capture = eRede.Capture(transaction, response.Tid);

            Assert.That(capture.Nsu, Is.Not.Empty);
        }
        catch (RedeException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Error);
        }
    }

    [Test]
    public void TestZeroDolarAuthorization()
    {
        var store = new Store(_ec, _token, _environment);
        var transaction = new Transaction
        {
            Amount = 20,
            Reference = "pedido" + new Random().Next(200, 10000)
        }.CreditCard(
            _cardNumber,
            _cardCvv,
            _expiration.Month.ToString(),
            _expiration.Year.ToString(),
            _cardHolder,
            false
        );

        var response = new eRede.eRede(store).Zero(transaction);

        Assert.AreEqual("174", response.ReturnCode);
        Assert.That(response.AuthorizationCode, Is.Not.Empty);
        Assert.That(response.Tid, Is.Not.Empty);
        Assert.That(response.Brand, Is.Not.Null);
        Assert.That(response.Brand.Name, Is.Not.Null);
        Assert.That(response.Brand.ReturnCode, Is.Not.Null);
        Assert.That(response.Brand.ReturnMessage, Is.Not.Null);
    }
}