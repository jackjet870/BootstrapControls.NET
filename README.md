# About

BootstrapControls.NET project is built with .NET 4.0 but it will surely work with a higher versions of .NET framework.

# Installation

The easiest way to add BootstrapControls.NET to your project is to clone this project into your existing or newly created solution reference it as a project and then register it in Web.config. You can still download the whole repository, unpack it and add it to your solution but you will **not be** able to sync with the latest version. 

1. Clone this repository to your solution directory.

	-- OR --

	Download the latest version of BootstrapControls.NET [here](./archive/master.zip) and unpack it to your solution folder (or clone it into your solution directory)
2. Add BootstrapControls.NET project to your solution by right-clicking on your solution -> Add -> Existing Project...![third_step.jpg](http://maple.com.pl/tutorial_bscontrols/third_step.jpg)
3. Add library reference in your Web Application project by right-clicking on References -> Add Reference... -> Projects -> BootstrapControls![fourth_step.jpg](http://maple.com.pl/tutorial_bscontrols/fourth_step.jpg)

Finally, register controls with your desired prefix. Insert following code into `<system.web>` node to register controls under "bs" prefix.
```xml
<pages>
  <controls>
    <add assembly="BootstrapControls" namespace="BootstrapControls" tagPrefix="bs"/>
  </controls>
</pages>
```

# Usage

To render control just start typing `<your_prefix: ...` , intellisense will show you available controls.

![qmK2lLhoYr.gif](http://maple.com.pl/tutorial_bscontrols/qmK2lLhoYr.gif)

#Documentation

1. Project structure and dependencies
2. Controls
	1. BreadCrumbs
	2. Button
	3. Checkbox
	4. DropDown
	5. LinkButton
	6. NotifyPanel
	7. Pagination (hot!)
	8. RadioButton (better than ASP.NET)
	9. TextBox

##Project structure and dependencies

If you've reached this section you probably have your BootstrapControls.NET installed in your solution (otherwise [see this](./#installation)) and your solution looks like:

![project_structure.JPG](http://maple.com.pl/tutorial_bscontrols/project_structure.JPG)

Yeah, you're ready now to use BootstrapControls.NET in your project. But there's one more thing that would make your life even better ! 
**Auto-generated BreadCrumbs** - that's what I'm talking about ! If you would like to have it in your project you'll need a `pages.json` in **the root of your Web Application project** file which holds your SITEMAP. Here's what it should look like:

```
{
  "pages": [
    {
      "pageIco": "fa-car",
      "pageUrl": "#",
      "pageLabel": "Super group",
      "subpages": [
        {
          "pageIco": "fa-car",
          "pageUrl": "/index.aspx",
          "pageLabel": "Index page",
          "subpages": [
            {
              "pageIco": "fa-car",
              "pageUrl": "page1.aspx",
              "pageLabel": "Index subpage 1",
              "subpages": []
            },
            {
              "pageIco": "fa-car",
              "pageUrl": "page2.aspx",
              "pageLabel": "Index subpage 2",
              "subpages": []
            }
          ]
        }
      ]
    },
    {
      "pageIco": "fa-heart",
      "pageUrl": "#",
      "pageLabel": "Super serce",
      "subpages": []
    }
  ]
}
```

The most important thing is you have to declare every property also `subpages` even if there's no subpage !! Remember that.

##Controls

I'll only explain properties which does not come from base ASP.NET Control.

###BreadCrumbs (requires pages.json [see this](./#project-structure-and-dependencies))

If you have your `pages.json` file in the root of your Web Application project (if not [check this](./#project-structure-and-dependencies)) you simply insert breadcrumb control in your desired place - can be Master page or a WebForm page.

The code:
```XML
<bs:BreadCrumbs runat="server" />
```
Properties:

This control has no properties

###Button

BootstrapControls.NET Button extends ASP.NET `System.Web.UI.WebControls.Button`

The code:
```XML
<bs:Button ID="btn1" runat="server" Text="Submit button" Block="false" Color="Success" Outline="false" Size="Large" />
```

Properties:

**Block** - Boolean - [Bootstrap Reference](http://getbootstrap.com/css/#buttons-sizes)

**Color** - Enum (Danger/Default/Info/Link/Primary/Success/Warning) - [Bootstrap Reference](http://getbootstrap.com/css/#buttons-options)

**Outline** - Boolean - [Bootstrap Reference](http://getbootstrap.com/css/#buttons-options)

**Size** - Enum (Large/Mini/Small/XtraLarge) **when not set - Normal !** [Bootstrap Reference](http://getbootstrap.com/css/#buttons-sizes)

###Checkbox

BootstrapControls.NET Checkbox extends ASP.NET `System.Web.UI.WebControls.Checkbox`

The code:
```XML
<bs:CheckBox ID="chk1" runat="server" Label="I accept the terms" Message="You probably forgot to check the checkbox" State="Error" />
```

Properties:

**Label** - Use it instead of Text **important!** Text property has been overrided and will not render anymore. [Bootstrap Reference](http://getbootstrap.com/css/#checkboxes-and-radios)

**Message** - You'll want to use it to show validation message along with the **State** property

**State** - Enum (Error/Info/Success/Warning) [Bootstrap Reference](http://getbootstrap.com/css/#forms-help-text)

###DropDown

BootstrapControls.NET DropDown extends ASP.NET `System.Web.UI.WebControls.DropDownList`

The code:
```XML
<bs:DropDown ID="ddl1" runat="server" Name="Some dropdown" Message="You probably forgot to choose an item" State="Error" Size="Normal" />
```

Properties:

**Name** - String - appears above the dropdown control

**Message** - You'll want to use it to show validation message along with the **State** property

**State** - Enum (Error/Info/Success/Warning) [Bootstrap Reference](http://getbootstrap.com/css/#forms-help-text)

**Size** - Enum (Big/Normal/Small) **when not set - Normal !** [Bootstrap Reference](http://getbootstrap.com/css/#forms-control-sizes)

###LinkButton

BootstrapControls.NET Button extends ASP.NET `System.Web.UI.WebControls.LinkButton`

The code:
```XML
<bs:LinkButton ID="lbtn1" runat="server" Text="Submit button" Block="false" Color="Success" Outline="false" Size="Large" />
```

Properties:

Check out [Button Control](./#button) as it has the same properties.

###NotifyPanel

NotifyPanel control has been built from the ground up and so it does not inherit any ASP.NET Control.

The code:
```XML
<bs:NotifyPanel ID="notify1" runat="server" State="Danger" Message="Something wen wrong!" Dismissable="true" />
```

Properties:

**Message** - String - You'll want to use it to show validation message along with the **State** property

**State** - Enum (Danger/Info/Success/Warning) - [Bootstrap Reference](http://getbootstrap.com/javascript/#alerts)

**Dismissable** - Boolean - [Bootstrap Reference](http://getbootstrap.com/javascript/#alerts)

###Pagination (hot!)

Pagination control has been built from the group up and so it does not inherit any ASP.NET Control. [Bootstrap Reference](http://getbootstrap.com/components/#pagination)

As it is the most advanced control in this collection I'll give it a little bit more attention. 

About:

BootstrapControls.NET Pagination Control lets you create a database related pagination to your web application. What makes it work is a special event `OnLoadData` which let's you send information to your databse how many records you want to show and what is the actual records offset.

The code:

```XML
<bs:Pagination ID="pag1" runat="server" RecordsPerQuery="5" MaxDisplayedPagerButtons="3" PaginationSide="Right" />
```

Properties:

**RecordsPerQuery** - Integer - sets how many records you want to fetch from database

**MaxDisplayedPagerButtons** - Integer - sets how many pages to show in your pagination control

**PaginationSide** - Enum (Left/Right) - sets where to place the pagination control floats left or right

**TotalRecords** (input) - Integer - you'll set this after when receiving data from the database **it is very important** as it will make pagination be able to calculate pages

**RecordsOffset** (output) - Integer - you'll use this property when getting data from the database

Events:

**LoadData** (OnLoadData) - BootstrapControls.Pagination - returns `BootstrapControls.Pagination pagination` object as a callback. You'll use it to get and set above properties and to bind your results to a repeater

```
protected void pagination_LoadData(BootstrapControls.Pagination pagination)
{
    List<object> list = new List<object>();

    for (int i = 0; i<100; i++)
    {
        list.Add(new { ID = i, Value = "val_" + i });
    }

    Repeater1.DataSource = list.Skip(pagination.RecordsOffset).Take(pagination.RecordsPerQuery).ToList();
    Repeater1.DataBind();

    pagination.TotalRecords = list.Count;
    
}
```

Methods:

**InitPagination** - Needs to be called on the Page_Load. Must be called when there's no PostBack

```
if (!IsPostBack)
{
    pagination.InitPagination();
}
```

Okay let me wrap everything up with this short tutorial

![S9jFhDGTzm.gif](http://maple.com.pl/tutorial_bscontrols/S9jFhDGTzm.gif)

###RadioButton

BootstrapControls.NET RadioButton extends ASP.NET `System.Web.UI.WebControls.RadioButton` but it has been improved to work well within repeaters ([reference](http://stackoverflow.com/questions/2164042/problem-with-html-radio-button-inside-repeater)). [Bootstrap Reference](http://getbootstrap.com/css/#checkboxes-and-radios)

About:

RadioButton control is an improved ASP.NET RadioButton Control - not only it was Bootstrap'd but also it was fixed to work well with repeaters which was impossible with ASP.NET base RadioButton Control !

The code:

```XML
<bs:RadioButton ID="RadioButton1" Value="1" Text="The first" GroupName="RadioGroup" runat="server"/>
<bs:RadioButton ID="RadioButton2" Value="2" Text="The second" GroupName="RadioGroup" runat="server"/>
<bs:RadioButton ID="RadioButton3" Value="3" Text="The third" GroupName="RadioGroup" runat="server"/>
<bs:RadioButton ID="RadioButton4" Value="4" Text="The fourth" GroupName="RadioGroup" runat="server"/>
```

Properties:

**Value** - String - Whatever value it is :) Can be an Eval or just a static value.

**Text** - String - Label for the checkbox

**GroupName** - String - Name for the radioButton group

**GroupValue** - String - Extracts value from the specified GroupName, for ex. `var x = RadioButton1.GroupValue;` will give you the value of a checked radio button

**IMPORTANT**

If you want to get a value from a radiobutton nested in a repeater you'll have to collect it from the Request Collection. I suppose it is clear for you that you can't get a value from within repeater without looping over repeater items.

Here's how to get the radio group value without looping over repeater items and getting value one-by-one

```
var x = Request["RadioGroup"];
```

This one was easy huh? :)

###TextBox

BootstrapControls.NET TextBox extends ASP.NET `System.Web.UI.WebControls.TextBox`

The code:

```XML
<bs:TextBox ID="tb1" runat="server" Ico="@" State="Error" Name="Some textfield" Message="You have to complete this field" Placeholder="Enter your text here ..." Size="Normal" />
```

**Ico** - String/HTML - [Bootstrap Reference](http://getbootstrap.com/css/#forms-inline)

**State** - Enum (Error/Info/Success/Warning) - [Bootstrap Reference](http://getbootstrap.com/css/#forms-help-text)

**Name** - String - appears above the dropdown control

**Message** - String - you'll want to use it to show validation message along with the **State** property

**Placeholder** - String - HTML5 textfield placeholder

**Size** - Enum (Big/Normal/Small)