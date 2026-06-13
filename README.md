# Unit Conversion Web API

A production-ready, highly extensible ASP.NET Core Web API that allows callers to convert numerical values between different units of measurement across various physical properties (e.g., Length, Weight/Mass, Temperature).

This solution is designed to scale effortlessly from handling a handful of default units to maintaining hundreds of units and conversion types over its lifecycle, making it an ideal foundational asset for an agile engineering team.

---

## 💻 Technical Stack & Local Execution

### System Requirements
* **SDK:** [net10.0 SDK]
* **IDE:** Visual Studio 2026, or VS Code equipped with C# Extensions.

### Local Initialization Instructions

1. **Clone the Project Repository:**
   ```bash
   git clone https://github.com/amolsm/unitConverter.git
   cd UnitConverter
   ```

2. **Restore Application Dependencies:**
   ```bash
   dotnet restore
   ```

3. **Compile the Solution Assembly:**
   ```bash
   dotnet build --configuration Release
   ```

4. **Execute the Web API Server:**
   ```bash
   dotnet run --project UnitConverter
   ```

5. **Access the Open-API Interactive Environment:**
   Once the console displays successful initialization logs, launch your browser and navigate to the local Swagger UI endpoint to inspect and test live interactions:
   * **Secure Gateway:** `https://localhost:7214/swagger`
   * **Standard Gateway:** `http://localhost:5214/swagger`

   ## 🗂️ Project Directory Structure

```text
UnitConverter/
│
├── Controllers/
│   └── ConversionController.cs       # REST API entry routing layer
│
├── Interfaces/
│   ├── IConversionService.cs         # Core orchestration contract
│   └── ICategoryConverter.cs     # Universal interface for category strategies

├── Models/
│   ├── ConversionRequest.cs          # Incoming payload contract validation
│   └── ConversionResponse.cs         # Formatted outgoing result payload
│
├── Services/
│   ├── ConversionService.cs          # Core strategy selector and manager
│   ├── LengthConverter.cs        # Matrix engine for Meters, Feet, Inches, Cm
│   ├── WeightConverter.cs        # Matrix engine for Kg, Lbs, Grams, Pounds
│   └── TemperatureConverter.cs   # Functional engine for Celsius, Fahrenheit, Kelvin│       
│
├── Program.cs                        # Bootstrapper, Dependency Injection & Middleware
├── appsettings.json                  # Application Configuration Profile
└── UnitConverterApi.csproj           # Build properties and project dependencies

---

## 📡 API Contract Specification & Payload Samples

### Primary Conversion Endpoint
* **HTTP Target:** `POST /api/conversion`
* **Headers:** `Content-Type: application/json`

#### Example 1: Length Transformation (Meters to Feet)
* **Payload Request:**
  ```json
  {
    "value": 25,
    "fromUnit": "meters",
    "toUnit": "feet"
  }
  ```
* **Success Output (200 OK):**
  ```json
  {
    "originalValue": 25,
    "fromUnit": "meters",
    "convertedValue": 82.020997,
    "toUnit": "feet",
    "category": "Length"
  }
  ```

#### Example 2: Temperature Transformation (Celsius to Fahrenheit)
* **Payload Request:**
  ```json
  {
    "value": 100,
    "fromUnit": "c",
    "toUnit": "fahrenheit"
  }
  ```
* **Success Output (200 OK):**
  ```json
  {
    "originalValue": 100,
    "fromUnit": "c",
    "convertedValue": 212,
    "toUnit": "fahrenheit",
    "category": "Temperature"
  }
  ```

#### Example 3: Invalid Cross-Category Unit Rejection
* **Payload Request:**
  ```json
  {
    "value": 12.5,
    "fromUnit": "kilograms",
    "toUnit": "meters"
  }
  ```
* **Failure Output (400 Bad Request):**
  ```json
  {
    "error": "Cannot convert 'kilograms' to 'meters'. They belong to different measurement categories."
  }
  ```

---