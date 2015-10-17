# About

BootstrapControls.NET project is built with .NET 4.0 but it will surely work with a higher versions of .NET framework.

# Installation

The easiest way to add BootstrapControls.NET to your project is to download the whole repository, unpack it, add to your solution and then register controls in your Web.config. 

1. Download the latest version of BootstrapControls.NET here - https://github.com/pablos91/BootstrapControls.NET/archive/master.zip
2. Unpack it to your solution folder
3. Add BootstrapControls.NET project to your solution by right-clicking on your solution -> Add -> Existing Project...![third_step.jpg](http://maple.com.pl/tutorial_bscontrols/third_step.jpg)
4. Add library reference in your Web Application project by right-clicking on References -> Add Reference... -> Projects -> BootstrapControls![fourth_step.jpg](http://maple.com.pl/tutorial_bscontrols/fourth_step.jpg)

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