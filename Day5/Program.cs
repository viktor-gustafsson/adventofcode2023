using Day5;

var data = File.ReadAllText("C:\\develop\\AdventOfCode2023\\Day5\\input.txt");
var strings = data.Split("\r\n\r\n");
var seeds = strings[0].Split(':')[1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
var seedToSoilMapInput = GetMap(strings[1]);
var soilToFertilizerMapInput = GetMap(strings[2]);
var fertilizerToWaterMapInput = GetMap(strings[3]);
var waterToLightMapInput = GetMap(strings[4]);
var lightToTemperatureMapInput = GetMap(strings[5]);
var temperatureToHumidityMapInput = GetMap(strings[6]);
var humidityToLocationMapInput = GetMap(strings[7]);

var seedToSoilMap = ConstructMap(seedToSoilMapInput);
var soilToFertilizerMap = ConstructMap(soilToFertilizerMapInput);
var fertilizerToWaterMap = ConstructMap(fertilizerToWaterMapInput);
var waterToLightMap = ConstructMap(waterToLightMapInput);
var lightToTemperatureMap = ConstructMap(lightToTemperatureMapInput);
var temperatureToHumidityMap = ConstructMap(temperatureToHumidityMapInput);
var humidityToLocationMap = ConstructMap(humidityToLocationMapInput);

long? result = null;
foreach (var seed in seeds)
{
    var seedLocation = FindSeedLocation(long.Parse(seed));
    if (result is null || result > seedLocation)
    {
        result = seedLocation;
    }
}

long? FindSeedLocation(long? seedId)
{
    //seed to soil
    var soilId = seedToSoilMap[seedId];
    // soil to fertilizer
    var fertilizerId = soilToFertilizerMap[soilId];
    // fertilizer to water
    var waterId = fertilizerToWaterMap[fertilizerId];
    // water to light
    var lightId = waterToLightMap[waterId];
    // light to temperature
    var temperatureId = lightToTemperatureMap[lightId];
    //temperature to humidity
    var humidityId = temperatureToHumidityMap[temperatureId];
    // humidity to location
    var locationId = humidityToLocationMap[humidityId];
    
    return locationId;
}

LazyMap ConstructMap(string[] mapInput)
{
    var map = new LazyMap();
    foreach (var input in mapInput)
    {
        map.AddRangeMapping(input);
    }

    return map;
}

string[] GetMap(string mapAsString)
{
    return mapAsString.Split("\r\n")[1..];
}

Console.WriteLine(result);