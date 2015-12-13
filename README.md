# A rich text editor sample for ASP.NET MVC project

A rich text editor example to integrate with MVC projects. It uses Redactor JS (an old version) and stores attachments (images, etc) on a disk.

# Usage

`Ctrl-F5` should work in most cases. Perhaps change the EF connection string, if you don't have LocalDb installed and would like to use a different SQL server.

# Usage in your own app

1. Add `RedactorController` to your app
1. Add Redactor nuget package (note the license! Redactor is not free)
1. Add Redactor assets to your layout
1. Add a special CSS class to your RTE text areas (could be improved with custom renderer based on DataType)
1. Add JS to initialize textareas as rich text controls:

	```html
	<script type="text/javascript">
    $(document).ready(
    	function()
    	{
    	    $('textarea.redactor_content').redactor({
    	        imageUpload: '@Url.RouteUrl("RedactorUpload")'
    	    });
    	}
    );
	<script>
	```
1. Create `Redactor` directory in `App_Data` folder (this folder will host your images)
1. Add route configuration:

    ```c#
    routes.MapRoute("RedactorUpload", "redactor/upload", new { controller = "Redactor", action = "Upload" });
    routes.MapRoute("RedactorResource", "redactor/get/{filename}", new { controller = "Redactor", action = "Get" });
    ```

# Future ideas

Automate this process so that it would be as simple as installing a nuget package.