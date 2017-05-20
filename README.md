# ThreeTier.NetAPP
Example to demonstrate creating a three tier app in ASp.net using C#
[![architecture.jpg](https://s9.postimg.org/phjbnesun/architecture.jpg)](https://postimg.org/image/z22yaai6j/)

First create an empty ASP.net Web application : File -> New Project -> ASP.net Web Application -> Give some name -> OK
[![pic1.png](https://s18.postimg.org/ezhxxmjex/pic1.png)](https://postimg.org/image/ukz9hkvd1/)

Next we will developing webForms using the empty template.
[![pic2.png](https://s18.postimg.org/wbb2djsk9/pic2.png)](https://postimg.org/image/qzw5su6hh/)

For creating three tier app, we need to first create the above three layers: Presentation, Logic and Data layer.
The presentation layer refers to the actual UI of the project, 
while data layer and Logic layer are implemented using the C# class libraries.
Another class library for passing the information across all the three layers is required and is termed as Business entity.

Now, to create class libraries : Right click on the solution -> Choose Add -> New Project -> Select Class library
[![pic3.png](https://s22.postimg.org/vlw83dag1/pic3.png)](https://postimg.org/image/vynm9jspp/)

Using the above method create three more class libraries. Now, we must end up with three class libraries: BusinessEntity, BusinessLogic(class library for the logic layer) and DAL(class library for the data layer)

Finally all the created class library needs to be interconnected to each other.
This can be done be adding references to each class library : Right click on a class library -> Add -> References.
One can search for the assembly or other class libraries to be added as references.

(1) The business entity should have reference to both the layer: Logic and Data layer.
(2) The data layer's class library has reference to the business entity and the logic layer.
(3) The logic layer's class library has reference to the business entity and the data layer.

Finally the project must have reference to all the three class libraries: BusinessEntity, BusinessLogic and DAL.
[![pic4.png](https://s1.postimg.org/sh7i4n9of/pic4.png)](https://postimg.org/image/hhmat1j97/)
