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

![image](https://user-images.githubusercontent.com/89914058/170766111-42a5a505-dce0-4fd7-b865-e88c5b843f85.png)

## Testplan
### Test Data

In the following tables you'll find all the data that is needed for testing.

#### Dish

| ID            | Input                             | Code                              |
| ------------- | --------------------------------- | --------------------------------- |
| `testAppetizer`  | price: 3.00f <br /> name: Tomatensoep <br /> appetizer: true <br /> mainCourse: false <br /> dessert: false | `new Dish(3.00f, "Tomatensoep", true, false, false)` |
| `testMainCourse` | price: 5.00f <br /> name: Chateau Briand <br /> appetizer: false <br /> mainCourse: true <br /> dessert: false | `new Dish(5.00f, "Chateau Briand", false, true, false)` |
| `testDessert`    | price: 2.00f <br /> name: Pavlova <br /> appetizer: false <br /> mainCourse: false <br /> dessert: true | `new Dish(2.00f, "Pavlova", false, false, true)` |

#### CateringCompany

| ID        | Input                                |  Code                        |
| --------- | ------------------------------------ | -----------------------------|
| `testCateringCompany` |  name: het lauwe soepje <br /> startDate: DateTime.Now <br /> endDate: DateTime.Now.AddDays(10)| `new CateringCompany("het lauwe soepje", DateTime.Now, DateTime.Now.AddDays(10))`|

#### Customer

| ID             | Input                                |  Code                 | 
| -------------- | ------------------------------------ | --------------------  | 
| `testCustomer1`|  name: Willem Engel <br /> wallet: 54.30f | `new Customer("Willem Engel", 54.30f)`  | 
| `testCustomer2`|  name: Frodo de 2e<br /> wallet: 24.14f   | `new Customer("Frodo de 2e", 24.14f)`   |

> <br />
> After instantiating all objects above, set all dishes in the CateringCompany class. <br /> 
> This way, 3 dishes will be set in the list of `availableDishes` variable <br />
> 
> Next to setting the dishes, also add the customers `testCustomer1` and `testCustomer2` to the cateringCompany. <br />
> In total, your `availableDishes` list should have 3 elements, and your `customers` list should have 2 elements.
> <br />


### Test Cases
#### Test A
Starting from the customer, order some dishes.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| name `String`, wallet `float` | `testCustomer1.orderDish("TomatenSoep", this.wallet)` | Dish (appetizer dish) |
|2| name `String`, wallet `float` | `testCustomer1.orderDish("Pavlova", this.wallet)` | Dish (dessert dish) |
|3| name `String`, wallet `float` | `testCustomer2.orderDish("Chateau Briand", this.wallet)` | Dish (maincourse dish) |

#### Test B
After ordering some dishes, your wallet value should be adjusted. Check the output of your wallet.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| - | `Console.WriteLine(testCustomer1.Wallet)` | 49.30 |
|2| - | `Console.WriteLine(testCustomer2.Wallet)` | 19.14 |

#### Test C
From the catering company, calculate the total revenue made
|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| - | `Console.WriteLine(testCateringCompany.calculateRevenue())` | 10.00 |

#### Test D
From the catering company, get the biggest consumer (customer that has had the most dishes)
|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| - | `testCateringCompany.getBiggestConsumer()` | Customer (`testCustomer1`) |

#### Test E
From the catering company, check how many dishes are still available in the `availableDishes` list. This should be 0 <br />
since all dishes were ordered.
|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| - | `Console.WriteLine(testCateringCompany.AvailableDishes.Count());` | 0 |

#### Test F
From the catering company, in the customers list, checkout how many dishes customer 1 has purchased. <br />
The first customer in this list should be testCustomer1.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| - | `Console.WriteLine(testCateringCompany.customers[0].OrderedDishes.Count());` | 2 |