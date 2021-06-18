using ShortTermLoan.App.Specs.Pages;
using ShortTermLoan.Spec.Framework;
using ShortTermLoan.Spec.Framework.DataProviders;
using ShortTermLoan.Spec.Framework.Evaluators;
using ShortTermLoan.Spec.Framework.Extensions;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace ShortTermLoan.App.Specs.FeatureSteps
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"I am using test data ""(.*)""")]
        public void GivenIAmUsingTestData(string filename)
        {
            ScenarioContext.Current.Add("testDataFilename", filename);
            Dictionary<string, string> testDataList = JsonDataReader.GetJsonDataFromFile(filename);
            foreach (KeyValuePair<string, string> kvp in testDataList)
                ScenarioContext.Current.Add(kvp.Key, kvp.Value);
        }
    }
}