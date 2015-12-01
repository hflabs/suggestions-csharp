using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace suggestionscsharp {

    [TestFixture]
    public class SuggestionsClientTest {

        public SuggestClient api { get; set; }

        [SetUp]
        public void SetUp() {
            var token = "ВАШ API-КЛЮЧ";
            var url = "https://dadata.ru/api/v2";
            this.api = new SuggestClient(token, url);
        }

        [Test]
        public void SuggestAddressTest() {
            var query = "москва турчанинов 6";
            var response = api.QueryAddress(query);
            Assert.AreEqual("119034", response.suggestionss[0].data.postal_code);
            Console.WriteLine(string.Join("\n", response.suggestionss));
        }

        [Test]
        public void SuggestBankTest() {
            var query = "сбербанк";
            var response = api.QueryBank(query);
            Assert.AreEqual("044525225", response.suggestionss[0].data.bic);
            Console.WriteLine(string.Join("\n", response.suggestionss));
        }

        [Test]
        public void SuggestEmailTest() {
            var query = "anton@m";
            var response = api.QueryEmail(query);
            Assert.AreEqual("anton@mail.ru", response.suggestionss[0].value);
            Console.WriteLine(string.Join("\n", response.suggestionss));
        }

        [Test]
        public void SuggestFioTest() {
            var query = "викт";
            var response = api.QueryFio(query);
            Assert.AreEqual("Виктор", response.suggestionss[0].data.name);
            Console.WriteLine(string.Join("\n", response.suggestionss));
        }

        [Test]
        public void SuggestPartyTest() {
            var query = "сбербанк";
            var response = api.QueryParty(query);
            Assert.AreEqual("7707083893", response.suggestionss[0].data.inn);
            Console.WriteLine(string.Join("\n", response.suggestionss));
        }

    }
}

