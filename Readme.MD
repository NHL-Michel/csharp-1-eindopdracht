# Startdocument for 'The catering company (Assignment 9).'

Startdocument of **Michel Disbergen**. Student number **4999738**.

## Problem Description

A company provides catering for people. For the period indicated
with a start date and an end date, the administration for a number of
customers are processed. One day a customer can order an appetizer (3 euros) and or a
main course (5 euros) and or a dessert (2 euros).
A program should be developed that enables each customer to
name, number of starters, number of main courses and number of desserts
is stored that the customer has had. Ultimately, the company wants to
presented the following information:

- The total revenue;
- The average turnover per day;
- The name of the customer who has the highest amount consumed;
- The name of the customers who have had appetizers but never had one dessert;
- The names of the customers who for an amount higher than the average per customer.

### Input & Output
In this section the in- and output of the application will be described.

#### Input
In the tables below all the input (that the user has to input in order to make the application work) are described.
##### Dish
|Case|Type|Conditions|function/method | additional info|
|-----|----|----------|----------------|----------------|
|float price|`float`| price > 0| constructor, setter| price of a dish |
|String name|`String`|not empty| constructor, setter| name of a dish |
|boolean appetizer|`boolean`| true or false | constructor, setter | specifies if the dish is an appetizer. If true, mainCourse and dessert must be false |
|boolean mainCourse|`boolean`| true or false | constructor, setter | specifies if the dish is a maincourse. If true, appetizer and dessert must be false |
|boolean dessert |`boolean`| true or false | constructor, setter| specifies if the dish is a dessert. If true, maincourse and appetizer must be false |
|DateTime dateSold |`DateTime`| - | setter| date the dish was sold to a customer |

##### CateringCompany
|Case|Type|Conditions|function/method | additional info|
|----|----|----------|----------------|----------------|
|String name|`String`|not empty| constructor, setter | name of the catering company |
|DateTime startDate|`DateTime`| full date, including year, month, day and time.| constructor, setter| day the catering company starts taking care of their customers which are related to a company |
|DateTime name|`DateTime`|full date, including year, month, day and time.| constructor, setter | day the catering company stops taking care of their customers which are related to a company |
|List\<Customer\> customers|`List<Customer>`|-| setter | all customers who have pruchased an appetizer, main course or dessert at the catering company |
|List\<Dish\> dishes|`List<Dish>`|-| setter | all dishes that the catering company has available for selling. |

##### Customer
|Case|Type|Conditions|function/method | additional info|
|----|----|----------|----------------|----------------|
|String name|`String`|not empty| constructor, setter | name of a customer |
|float wallet|`float`|-| constructor, setter | the amount of money a customer has in his/her wallet |
|List\<Dish\> orderedDishes|`List<Dish>`|-| setter | a list of all the dishes that a customer has consumed from the catering company |


#### Output
##### Dish
|Case|Type|function/method|
|----|----|---------------|
|Get the price of a dish |`float`|Price()|
|Get the name of a dish|`String`|Name()|
|Get the date the dish was sold to a customer|`DateTime`|DateSold()|
|Get the result if the dish is a appetizer |`Boolean`|Appetizer()|
|Get the result if the dish is a maincourse|`Boolean`|MainCourse()|
|Get the result if the dish is a dessert |`Boolean`|Dessert()|

##### CateringCompany
|Case|Type|function/method|
|----|----|---------------|
|Get the name of the catering company |`String`|Name()|
|Get the list of customers |`List<Customer>`|Customers()|
|Get all available dishes|`List<Dish>`|AvailableDishes()|
|Get the startdate of when the catering company is taking care of the catering |`DateTime`|StartDate()|
|Get the enddate of when the catering company is taking care of the catering |`DateTime`|EndDate()|
|Get the entire revenue the catering company has made |`float`|calculateRevenue()|
|Calculate the average revenue over a specific date |`float`|calculateAverageRevenue()|
|Retrieve the biggest consumer in customer terms |`Customer`|getBiggestConsumer()|
|Get all customers that have had appetizers, but no desserts |`List<Customer>`|getAppetizerCustomer()|
|Get all the customers that have spend money on dishes which is above average |`List<Customer>`|getAboveAverageCustomers()|

##### Customer
|Case|Type|function/method|
|----|----|---------------|
|Get the name of a customer |`String`|Name()|
|Get the amount of money a customer has in his wallet |`float`|Wallet()|
|Retrieve all dishes that a specific customer has ordered|`List<Dish>`|OrderedDishes()|
|Order a dish as a customer |`Dish`|orderDish()|
## Class Diagram

![image](https://user-images.githubusercontent.com/89914058/158354399-477d03be-702f-4a48-a621-afd2dab4c512.png)

## Testplan
### Test Data

In the following tables you'll find all the data that is needed for testing.

#### Athlete

| ID            | Input                             | Code                              |
| ------------- | --------------------------------- | --------------------------------- |
| `athleteOne`  | firstName: Sven<br /> lastName: Kramer <br /> specialization: hardloper | `new Athlete("Sven", "Kramer", "hardloper")` |
| `athleteTwo`  | firstName: Ireen<br /> lastName: Wust <br /> specialization: hardloper   | `new Athlete("Ireen", "Wust", "hardloper")`       |

#### Club

| ID        | Input                                |  Code                        |
| --------- | ------------------------------------ | -----------------------------|
| `club`    |  name: De harde renner               | `new Club("De harde renner")`|

#### Track

| ID             | Input                                |  Code                 | additional info |
| -------------- | ------------------------------------ | --------------------  | --------------- |
| `tempTrack`    |  name: De harde renner               | `new Track("Imola")`  | This is best done in the Athlete object which has the method addTrack() |
| `tempTrack`    |  name: De snelle wind                | `new Track("Bahrein")`| This is best done in the Athlete object which has the method addTrack() |

#### Lap

| ID           | Input               | Code            |additional info |
| ------------ | ------------------- | --------------- | ---------------|
| `tempLap`    | time: `20`     | `new Lap(15)`        | This is done inside the Track Object|
| `tempLap`    | time: `20`     | `new Lap(17)`        | This is done inside the Track Object|
| `tempLap`    | time: `20`     | `new Lap(20)`        | This is done inside the Track Object|
| `tempLap`    | time: `30`     | `new Lap(30)`        | This is done inside the Track Object|
| `tempLap`    | time: `30`     | `new Lap(35)`        | This is done inside the Track Object|
| `tempLap`    | time: `40`     | `new Lap(40)`        | This is done inside the Track Object|

#### Attach Athlete to club, attach track to athlete, attach lap to a track which is part of an athlete

| Order        | Code                      | additional info |
| ------------ | ------------------------- | --------------- |
| `AthleteOne` | `club.addMember(Athlete athlete)` | This is done inside the Club object   |
| `tempTrack`  | `athlete.addTrack(String name)` | This is done inside the Athlete object|
| `tempLap`    | `athlete.getTrack(int index).AddLap(int time)` | This is done inside the track object|


### Test Cases
#### test A
Starting from the athlete object, request the fastest lap.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `trackIndex int` | `athleteOne.getFastestTrack().getFastestLap()` | 15 |
|2| `trackIndex int` | `athleteTwo.getFastestTrack().getFastestLap()` | 17 |
#### test B
From the athlete object, get the total time the athlete has been on a track.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `trackIndex int` | `athleteOne.getTotalTime(0)` | 125 |
|2| `trackIndex int` | `athleteTwo.getTotalTime(1)` | 65 |
|3| `trackIndex int` | `athleteOne.getTotalTime(0)` | 90 |
|4| `trackIndex int` | `athleteTwo.getTotalTime(1)` | 67 |

#### test C 
From the athlete object, get the average time per lap set on a specific track.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `trackIndex int` | `athleteOne.getAverageTime(0)` | 31 |
|2| `trackIndex int` | `athleteTwo.getAverageTime(0)` | 21 |

#### test D
From the athlete, get the the distance in km made on a specific track.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `trackIndex int` | `athleteOne.getDistanceInKm(0)` | 1.6 |
|2| `trackIndex int` | `athleteOne.getDistanceInKm(1)` | 1.2 |

#### test E
From the athlete object, get the max speed someone has set on a track (in meter per seconds)

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `trackIndex int` | `athleteOne.getMaxSpeed(0)` | 20 |
|2| `trackIndex int` | `athleteOne.getMaxSpeed(1)` | 26 |
#### test F
From the club object, retrieve the fastest athlete. This is based on all tracks

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `empty` | `club.getFastestAthlete().getFirstName()` | Sven |
|2| `empty` | `club.getFastestAthlete().getFastestTrack().getFastestLap()` | 15 |
