# ReflectExport

A .NET 8 library for exporting data to CSV and JSON formats, leveraging reflection and custom attributes for flexible and dynamic data handling.

## Table of Contents

- [About The Project](#about-the-project)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)

## About The Project

ReflectExport is a lightweight library designed to simplify the process of exporting data to CSV and JSON formats. By using custom attributes, developers can annotate their models to define which properties should be included in the export and customize column names. This approach minimizes boilerplate code and enhances maintainability.

### Features

- Export data to CSV format with customizable column names.
- Export data to JSON format with structured output.
- Attribute-based configuration for flexibility.
- Supports collections of objects.

## Getting Started

### Prerequisites

- .NET 8 SDK installed on your machine.

### Installation

1. Clone the repository:

   git clone https://github.com/gabrielvieiraes/ReflectExport.git

2. Navigate to the project directory:
   
   cd ReflectExport

3. Build the project:
   
   dotnet build


## Usage

### Example: Exporting Users to CSV

1. Annotate your model properties with `ExportColumnAttribute` and `ExportColumnNameAttribute`:
   
	public class User { [ExportColumn] [ExportColumnName("Identificador")] public int Id { get; set; }
	   [ExportColumn]
	   [ExportColumnName("Primeiro nome")]
	   public string FirstName { get; set; }

	   // Additional properties...
	}

2. Use the `ExportService` to export data:
   
	var users = new List<User> { new User { Id = 1, FirstName = "John" }, new User { Id = 2, FirstName = "Jane" } };
	var exportService = new ExportService(); var csv = exportService.ExportCSV(users); Console.WriteLine(csv);


### Example: Exporting Users to JSON

	var json = exportService.ExportJson(users); Console.WriteLine(json);


## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the project.
2. Create your feature branch:
   
	git checkout -b feature/AmazingFeature

3. Commit your changes:
   
	git commit -m 'Add some AmazingFeature'

4. Push to the branch:
	
	git push origin feature/AmazingFeature

5. Open a pull request.