# Grades

## Introduction
The portal allows you to easily display grades retrieved from a (custom) API. This section will cover the basics to create your endpoint for use in the portal.

## Sample
The portal requires the output data to be a [OdataContainer](https://github.com/synigopulse/oneapi/blob/main/Synigo.OneApi.Model/OdataContainer.cs), see example below.

```csharp
...

public async Task<HttpResponseData> GetGrades(int pageNumber, int pageSize) {
  List<Association<Result>> grades = ...; // Retrieve all relevant grades from the MS Graph

  // It's recommended to apply pagination
  List<Association<Result>> associations = grades
        .Skip(pageSize * (pageNumber - 1))
        .Take(pageSize)
        .ToList();

  // This is to indicate that there's more data
  string nextLink = grades.Count > pageSize * pageNumber ? $"?pageNumber={pageNumber+1}&pageSize={pageSize}" : null;

  // Convert the grades to a model the portal can understand.
  OdataContainer<List<Association<Result>>> container = new OdataContainer<List<Association<Result>>>()
  {
      Value = associations,
      Type = Association<Result>.ModelType, // "https://openonderwijsapi.nl/v4/model#association"
      Count = results.Count,
      NextLink = nextLink
  };

  string json = JsonSerializer.Serialize(container);
  await response.WriteStringAsync(json);

  return response;
}

...
```

This results in the following json:

Note: the following sample does not cover all properties from the Association<Result> object.

```json
{
	"@odata.type": "https://openonderwijsapi.nl/v4/model#association",
	"@odata.nextLink": "http://localhost:48770/Grades/test?pageNumber=2&pageSize=10",
	"@odata.count": 30,
	"value": [
		{
			"result": {
				"resultId": "26d25df6-e606-448e-8690-70c93f555c1e",
				"state": "Completed",
				"comment": "Recusabo commune vim quo deseruisse equidem illum duo sanctus nobis munere vidit hendrerit aliquip indoctum petentium.",
				"score": "5",
				"resultDate": "2021-05-08T00:00:00",
				"ext": {}
			},
			"associationId": "90747168-8dec-45c6-a261-e3c58e2e53de",
			"type": "ComponentOfferingAssociation",
			"role": "Student",
			"state": "Associated",
			"person": {
				"personId": "00000000-0000-0000-0000-000000000000",
				"displayName": "Fabellas Ceteros",
				"cityOfBirth": "Gorinchem",
				"affiliations": [],
				"address": {
					"addressId": "00000000-0000-0000-0000-000000000000",
					"type": "Postal"
				}
			},
			"offering": {
				"offeringId": "12d84d75-a372-4aae-b528-1fbce49e61d8",
				"type": "Course",
				"academicSession": {
					"academicSessionId": "00000000-0000-0000-0000-000000000000",
					"startDate": "0001-01-01T00:00:00",
					"endDate": "0001-01-01T00:00:00"
				},
				"name": "Elitr",
				"abbreviation": "velit",
				"description": "Faćer signiferumque ubique autem omnis atdeleniti commune ubique populo velit sadipscing repudiare mediocritatem etdetracto primis sed scribentur erant facer tale praesent oportere graeci feugait est.",
				"mainLanguage": "nl-NL",
				"maxNumberStudents": 10,
				"enrolledNumberStudents": 1,
				"pendingNumberStudents": 1,
				"isLineItem": true,
				"resultValueType": "PassOrFail",
				"startDate": "0001-01-01T00:00:00",
				"endDate": "0001-01-01T00:00:00",
				"ext": {}
			},
			"ext": {}
		},
    ...
	]
}
```
