using Eurowings.Controllers;
using Eurowings.Model;
using Eurowings.Specs.Mock;
using Machine.Specifications;
using Microsoft.AspNetCore.Mvc;
using It = Machine.Specifications.It;

namespace Eurowings.Specs.Controllers;

[Subject(typeof(FlightsController))]
class When_getting_all_flights : WithStaticTestData
{
    Because of = () => Result = Subject.GetAllFlightsAsync().GetAwaiter().GetResult();

    It should_return_not_null = () => Result.ShouldNotBeNull();
    It should_return_ok = () => Result.Result.ShouldBeOfExactType<OkObjectResult>();
    It should_return_9_flights = () => ((Result.Result as OkObjectResult)!.Value as IEnumerable<Flight>)!.Count().ShouldEqual(9);

    static ActionResult<IEnumerable<Flight>> Result;
}

[Subject(typeof(FlightsController))]
class When_searching_flights_from_CGN_to_MUC : WithStaticTestData
{
    Because of = () => Result = Subject.GetAllFlightsByCriteriaAsync(from:"CGN", to:"MUC").GetAwaiter().GetResult();

    It should_return_not_null = () => Result.ShouldNotBeNull();
    It should_return_ok = () => Result.Result.ShouldBeOfExactType<OkObjectResult>();
    It should_return_1_flight = () => ((Result.Result as OkObjectResult)!.Value as IEnumerable<Flight>)!.Count().ShouldEqual(1);

    static ActionResult<IEnumerable<Flight>> Result;
}

[Subject(typeof(FlightsController))]
class When_searching_flights_from_MUC_to_FRA_with_airline_LH : WithStaticTestData
{
    Because of = () => Result = Subject.GetAllFlightsByCriteriaAsync(from: "MUC", to: "FRA", airline:"LH").GetAwaiter().GetResult();

    It should_return_not_null = () => Result.ShouldNotBeNull();
    It should_return_ok = () => Result.Result.ShouldBeOfExactType<OkObjectResult>();
    It should_return_1_flight = () => ((Result.Result as OkObjectResult)!.Value as IEnumerable<Flight>)!.Count().ShouldEqual(1);

    static ActionResult<IEnumerable<Flight>> Result;
}

[Subject(typeof(FlightsController))]
class When_searching_flights_from_CGN : WithStaticTestData
{
    Because of = () => Result = Subject.GetAllFlightsByCriteriaAsync(from: "CGN").GetAwaiter().GetResult();

    It should_return_not_null = () => Result.ShouldNotBeNull();
    It should_return_ok = () => Result.Result.ShouldBeOfExactType<OkObjectResult>();
    It should_return_3_flights = () => ((Result.Result as OkObjectResult)!.Value as IEnumerable<Flight>)!.Count().ShouldEqual(3);

    static ActionResult<IEnumerable<Flight>> Result;
}

[Subject(typeof(FlightsController))]
class When_searching_flights_with_airline_EW : WithStaticTestData
{
    Because of = () => Result = Subject.GetAllFlightsByCriteriaAsync(airline: "EW").GetAwaiter().GetResult();

    It should_return_not_null = () => Result.ShouldNotBeNull();
    It should_return_ok = () => Result.Result.ShouldBeOfExactType<OkObjectResult>();
    It should_return_7_flights = () => ((Result.Result as OkObjectResult)!.Value as IEnumerable<Flight>)!.Count().ShouldEqual(7);

    static ActionResult<IEnumerable<Flight>> Result;
}

[Subject(typeof(FlightsController))]
class When_searching_for_a_flight_with_from_code_more_than_3_letters : WithStaticTestData
{
    Because of = () => Result = Subject.GetAllFlightsByCriteriaAsync(from:"ABCD").GetAwaiter().GetResult();

    It should_return_not_null = () => Result.ShouldNotBeNull();
    It should_return_bad_request = () => Result.Result.ShouldBeOfExactType<BadRequestObjectResult>();

    static ActionResult<IEnumerable<Flight>> Result;
}

[Subject(typeof(FlightsController))]
class When_searching_for_a_flight_with_to_code_more_than_3_letters : WithStaticTestData
{
    Because of = () => Result = Subject.GetAllFlightsByCriteriaAsync(to: "ABCD").GetAwaiter().GetResult();

    It should_return_not_null = () => Result.ShouldNotBeNull();
    It should_return_bad_request = () => Result.Result.ShouldBeOfExactType<BadRequestObjectResult>();

    static ActionResult<IEnumerable<Flight>> Result;
}

[Subject(typeof(FlightsController))]
class When_searching_for_a_flight_with_airline_code_more_than_50_letters : WithStaticTestData
{
    Because of = () => Result = Subject.GetAllFlightsByCriteriaAsync(airline: "012345678901234567890123456789012345678901234567890").GetAwaiter().GetResult();

    It should_return_not_null = () => Result.ShouldNotBeNull();
    It should_return_bad_request = () => Result.Result.ShouldBeOfExactType<BadRequestObjectResult>();

    static ActionResult<IEnumerable<Flight>> Result;
}

abstract class WithStaticTestData
{
    Establish context = () =>
    {
        Subject = new FlightsController(new FlightServiceMock());
    };

    protected static FlightsController Subject;
}