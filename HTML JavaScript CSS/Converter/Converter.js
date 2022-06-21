/*
Converter App using Node.
Meant to demonstrate the use of several basic aspects of the JavaScript language as a CLI program.
Useful article: https://nodejs.org/en/knowledge/command-line/how-to-parse-command-line-arguments/
Potentially useful third-party packages from the node package manager repository:
yargs: https://www.npmjs.com/package/yargs
commander: https://www.npmjs.com/package/commander
unit conversions: 
https://www.unitconverters.net/
https://www.checkyourmath.com/
*/

const usageMessage = 
`
Usage: node converter.js <unit-from> <unit-to> <value-to-convert>
    length units:
        km: kilometers
        mi: miles    
        nm: nautical-miles        
        m: meters
        cm: centimeters
        y: yards        
        f: feet
    temperature units:
        C: celsius
        F: fahrenheit
        K: kelvin
    weight units:
        kg: kilograms
        g: grams
        lbs: pounds
        oz: ounces
`;

/**
 * Contain descriptors for a unit type
 * 
 * Using JavaScript classes - https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes to 
 * collect various aspects about a UnitType in one place.
 * 
 * Also overrides Object.prototype.tostring
 */
class UnitType {

    abbreviation = '';  //unit abbreviation
    name = '';          //unit name
    type = '';          //unit type

    /* used to accept arguments required to construct a new instance */
    constructor(abbr, name, type) {
        this.abbreviation = abbr;
        this.name = name;
        this.type = type;
    }

    toString() {
        return `${this.abbreviation} | ${this.name} | ${this.type}`;
    }
    
}

// list of units
const units = 
[
    // length units:
    new UnitType('km', 'kilometers', 'length'),     // km: kilometers
    new UnitType('mi', 'miles', 'length'),          // mi: miles
    new UnitType('nm', 'nautical-miles', 'length'), // nm: nautical miles
    new UnitType('m', 'meters', 'length'),          // m: meters
    new UnitType('cm', 'centimeters', 'length'),    // cm: centimeters
    new UnitType('y', 'yards', 'length'),           // y: yards
    new UnitType('f', 'feet', 'length'),            // f: feet
    
    // temperature units:
    new UnitType('C', 'celsius', 'temperature'),    // C: celsius
    new UnitType('F', 'fahrenheit', 'temperature'), // F: fahrenheit
    new UnitType('K', 'kelvin', 'temperature'),     // K: kelvin
    
    // weight units:
    new UnitType('kg', 'kilograms', 'weight'),      // kg: kilograms
    new UnitType('g', 'grams', 'weight'),           // g: grams
    new UnitType('lbs', 'pounds', 'weight'),        // lbs: pounds
    new UnitType('oz', 'ounces', 'weight'),         // oz: ounces    
];

/* You might consider writing a method to check to see if the conversion provided
 * as an argument is in the list above
 */
function isInUnitsList(unit) {
     return units.some(u=>u.abbreviation);
}
function isNumeric(value) {
     return !isNaN(value);
}
/* This takes each of the parts and performs the conversion operation
 * first - the first unit type to convert - assumed to be either the abbrevation or the name
 */
function processConversion(first, second, value) {

    let converted = 0;

    /* I started this for you.  I use nested switches to cover the combinations */

    // look at the first arg
switch(first) {
// LENGTHS ////////////////////////////////////////////////////////////
    case 'km':
    case 'kilometers':
    // applicable second args for km
        switch(second) {
            // mi: miles                   
            case "mi":
            case "miles":
            // https://www.unitconverters.net/length/km-to-miles.htm
            converted = value * 0.6213711922;

            break;
            // nm: nautical miles
            case "nm":
            case "nautical-miles":
            // https://www.checkyourmath.com/convert/length/km_nautical_miles.php
            converted = value / 1.852; 
            break;
            // m: meters
            case "m":
            case "meters":
            // https://www.unitconverters.net/length/km-to-m.htm
            converted = value * 1000;
            break;
            // cm: centimeters
            case "cm":
            case "centimeters":
            // https://www.unitconverters.net/length/m-to-cm.htm                    
            converted = value * 1000 * 100;
            break;
            // y: yards
            case "y":
            case "yards":
            // https://www.unitconverters.net/length/kilometer-to-yard.htm
            converted = value * 1093.6132983377;
            break;
            // f: feet
            case "f":
            case "feet":
            // https://www.unitconverters.net/length/kilometer-to-foot.htm
            converted = value * 3280.8398950131;
            break;
            }
            break;

    case "mi":
    case "miles":
            switch(second) {
            // km: kilometers
                case "km":
                case "kilometers":
                // https://www.unitconverters.net/length/miles-to-km.htm
                converted = value * 1.609344;
                break;
                // nm: nautical-miles
                case "nm":
                case "nautical-miles":
                // https://www.checkyourmath.com/convert/length/km_nautical_miles.php
                converted = value / 1.15078; 
                break;
                // m: meters
                case "m":
                case "meters":
                // https://www.checkyourmath.com/convert/length/miles_m.php
                converted = value * 1609.344;
                break;
                // cm: centimeters
                case "cm":
                case "centimeters":
                // https://www.checkyourmath.com/convert/length/miles_cm.php          
                converted = value * 1000 * 160934.4;
                break;
                case "y":
                case "yards":
                // https://www.checkyourmath.com/convert/length/miles_yards.php
                converted = value * 1760;
                break;
                // f: feet
                case "f":
                case "feet":
                // https://www.checkyourmath.com/convert/length/miles_feet.php
                converted = value * 5280;
                break;
                }
                break;
    case "nm":
    case "nautical-miles":
        switch(second) {
            // km: kilometers
            case "km":
            case "kilometers":
            // https://www.unitconverters.net/length/miles-to-km.htm
            converted = value * 1.852;
            break;
            //mi: miles
            case "mi":
            case "miles":
            // https://www.checkyourmath.com/convert/length/km_nautical_miles.php
            converted = value * 1.15078; 
            break;
            // m: meters
            case "m":
            case "meters":
            // https://www.checkyourmath.com/convert/length/miles_m.php
            converted = value * 1852;
            break;
            // cm: centimeters
            case "cm":
            case "centimeters":
            // https://www.checkyourmath.com/convert/length/miles_cm.php          
            converted = value * 185200;
            break;
            case "y":
            case "yards":
            // https://www.checkyourmath.com/convert/length/miles_yards.php
            converted = value * 2025.37;
            break;
            // f: feet
            case "f":
            case "feet":
            // https://www.checkyourmath.com/convert/length/miles_feet.php
            converted = value => value * 6076.12;
            break;
            }
            break;


            // continue with this on your own
            // remember to also do temperature and weight
    case "m":
    case "meters":
        switch(second) {
            // km: kilometers
            case "km":
            case "kilometers":
            // 
            converted = value / 1000;
            break;
            // nm: nautical-miles
            case "nm":
            case "nautical-miles":
            // 
            converted = value /1852; 
            break;
            // m: miles
            case "mi":
            case "miles":
            // /1609;
            break;
            // cm: centimeters
            case "cm":
            case "centimeters":
            //         
            converted = value * 100;
            break;
            case "y":
            case "yards":
            // 
            converted = value * 1.09361;
            break;
            // f: feet
            case "f":
            case "feet":
            // https://www.checkyourmath.com/convert/length/miles_feet.php
            converted = value * 3.28084 ;
            break;
            }
            break;

    case "cm":
    case "centimeters":
        switch(second) {
            // km: kilometers
            case "km":
            case "kilometers":
            // https://www.unitconverters.net/length/miles-to-km.htm
            converted = value / 100000;
            break;
            // nm: nautical-miles
            case "nm":
            case "nautical-miles":
            // https://www.checkyourmath.com/convert/length/km_nautical_miles.php
            converted = value / 185200; 
            break;
            // m: meters
            case "m":
            case "meters":
            // https://www.checkyourmath.com/convert/length/miles_m.php
            converted = value * 100;
            break;
            // cm: centimeters
            case "mi":
            case "miles":
            // https://www.checkyourmath.com/convert/length/miles_cm.php          
            converted = value / 1609;
            break;
            case "y":
            case "yards":
            // https://www.checkyourmath.com/convert/length/miles_yards.php
            converted = value * 1.094;
            break;
            // f: feet
            case "f":
            case "feet":
            // https://www.checkyourmath.com/convert/length/miles_feet.php
            converted = value => value * 3.281;
            break;
            }
            break;

    case "y":
    case "yards":
        switch(second) {
            // km: kilometers
            case "km":
            case "kilometers":
            // https://www.unitconverters.net/length/miles-to-km.htm
            converted = value / 1094;
            break;
            // nm: nautical-miles
            case "nm":
            case "nautical-miles":
            // https://www.checkyourmath.com/convert/length/km_nautical_miles.php
            converted = value /2025; 
            break;
            // m: meters
            case "m":
            case "meters":
            // https://www.checkyourmath.com/convert/length/miles_m.php
            converted = value /1.094;
            break;
            // cm: centimeters
            case "cm":
            case "centimeters":
            // https://www.checkyourmath.com/convert/length/miles_cm.php          
            converted = value * 91.44;
            break;
            case "m":
            case "miles":
            // https://www.checkyourmath.com/convert/length/miles_yards.php
            converted = value /1760;
            break;
            // f: feet
            case "f":
            case "feet":
            // https://www.checkyourmath.com/convert/length/miles_feet.php
            converted = value  * 3;
            break;
            }
            break;

    case "f":
    case "feet":
            switch(second) {
            // km: kilometers
            case "km":
            case "kilometers":
            // https://www.unitconverters.net/length/miles-to-km.htm
            converted = value / 3281;
            break;
            // nm: nautical-miles
            case "nm":
            case "nautical-miles":
            // https://www.checkyourmath.com/convert/length/km_nautical_miles.php
            converted = value / 6076; 
            break;
            // m: meters
            case "m":
            case "meters":
            // https://www.checkyourmath.com/convert/length/miles_m.php
            converted = value / 3.281;
            break;
            // cm: centimeters
            case "cm":
            case "centimeters":
            // https://www.checkyourmath.com/convert/length/miles_cm.php          
            converted = value * 30.48;
            break;
            case "y":
            case "yards":
            // https://www.checkyourmath.com/convert/length/miles_yards.php
            converted = value * 3;
            break;
            // mi: miles
            case "mi":
            case "miles":
            // https://www.checkyourmath.com/convert/length/miles_feet.php
            converted =  value / 5280;
            break;
            }
            break;
// Temperatures ////////////////////////////////////////////////////////////
    case "C":
    case "celsius":
        switch(second) {
            // F : farenheit
            case "F":
            case "farenheit":
            // 
            converted = (value *(9/5))+32;
            break;
            // K: kelvin
            case "K":
            case "kelvin":
            // 
            converted = value + 273.15; 
            break;

            }
            break;
    case "F":
    case "farenheit":
        switch(second) {
            // C : fcelsius
            case "C":
            case "celsius":
                // 
                converted = (value -32)*(5/9);
                break;
            // K: kelvin
            case "K":
            case "kelvin":
                // 
                converted = (value -32)*(5/9) + 273.15; 
                break;

        }
                break;
            case "K":
            case "Kelvin":
                switch(second) {
                // C : celsius
                case "C":
                case "celsius":
                    converted = (value -32)*(5/9);
                    break;
                // F: farenheit
                case "F":
                case "farenheit":
                    converted = (value -273.15)*(9/5) + 32; 
                    break;

            }
                break;
// Weight ////////////////////////////////////////////////////////////
    case "kg":
    case "kilograms":
        switch(second) {
            // g : grams
            case "g":
            case "grams":
            // 
            converted = value * 1000 ;
            break;
            // lbs: pounds
            case "lbs":
            case "pounds":
            // 
            converted = value * 2.205; 
            break;
            // lbs: pounds
            case "oz":
            case "ounces":
            // 
            converted = value * 35.274; 
            break;                

        }
            break;
    // if no path above matches, we'll return zero - you should check for this 
    
    case "g":
    case "grams":
            switch(second) {
                // kg : grams
                case "kg":
                case "kilograms":
                // 
                converted = value / 1000 ;
                break;
                // lbs: pounds
                case "lbs":
                case "pounds":
                // 
                converted = value / 454; 
                break;
                // lbs: pounds
                case "oz":
                case "ounces":
                // 
                converted = value / 28.35; 
                break;                
    
            }
                break;
        case "lbs":
        case "pounds":
            switch(second) {
                // kg : kilograms
                case "kg":
                case "kilograms":
                // 
                converted = value / 2.205 ;
                break;
                // g: grams
                case "g":
                case "grams":
                // 
                converted = value * 454; 
                break;
                // oz: ounces
                case "oz":
                case "ounces":
                // 
                converted = value / 28.35; 
                break;                
        
                }
                break;
        case "oz":
        case "ounces":
            switch(second) {
                // kg : kilograms
                case "kg":
                case "kilograms":
                // 
                converted = value / 35.274 ;
                break;
                // g: grams
                case "g":
                case "grams":
                // 
                converted = value * 28.35; 
                break;
                // lbs: pounds
                case "lbs":
                case "pounds":
                // 
                converted = value / 16; 
                break;                
    
            }
                
                
                   
        // if no path above matches, we'll return zero - you should check for this 
        }
    
   return converted; 

}


function main(){

    // hold the three arguments
    let first = null;
    let second = null;
    let value = 0;
    

    if (process.argv.length > 2) {

        // the first two arguments are node and the name of the file
        const args = process.argv.slice(2);
        if (isInUnitsList(args[0])&& isInUnitsList(args[1])){
            first=args[0];
            second=args[1];
                    }
        else{
            console.log(`unit type ${args[0]} and/or ${args[1]} unknown`);
            throw `unit type ${args[0]} and/or ${args[1]} unknown`;
        }
        // value
        if(isNumeric(args[2])){
            value=parseFloat(args[2]);
        } else{
            throw "value not a number";
        }
        
         let converted = processConversion(first, second, value);  
         if(converted!=0){ 
         console.log(`${value} ${first} to ${second} is ${converted.toFixed(2)} ${second}`);
         
         }

        }else {
        /* if the correct number of arguments isn't given, remind how to use this utility */
        console.log("Hello");
        console.log(usageMessage);
        }
}

main();
