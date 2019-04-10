# What is this about?

It's a console application which is able to query the Azure Active Directory.

## How do I set this up?

Setting this up in order to get the application to function requires a bit of work inside the Azure Active Directory.

### First steps

**First thing** you need to do is navigate to your Azure Active Directory.

Over there you need to create a new `Application registration`. 
This will create a new application inside the Azure Active Directory (AAD).

Once this is done you'll see a couple of guids in the application's overview page. The guid you are interested in is called the `Application ID`. Note this somewhere, you'll be needing it later on.

**Next thing** you need to do is to create a new `Key`. 
This key will act as the `ClientSecret` you probably know from every OAuth2 flow. 
After having created this key, copy it somewhere. This is the only moment you'll be able to see the actual value of the key. 
If you forget, you'll have to create a new one!

**Last thing** we need to do over here is to add the appropriate permissions to the AAD for your Application.
What this application needs is `Read directory data` from the Azure Active Directory. 
You should be able to find this in one of the blades of your application.

### Next steps

The hard part is over!

The only thing you need to do now is set all of the settings in the `app.config` file of the project.

	<add key="TenantId" value="[The tenant id of the AAD you want to query]"/>
	<add key="TenantName" value="[The name of the AAD tenant you want to query]"/>
	<add key="ClientId" value="[The GUID which represents the created application in the AAD]"/>
	<add key="ClientSecret" value="[The secret you have created for the application]"/>

The `TenantId` is the identifier of your tenant. You should be able to find this in the properties blade of your AAD, it's probably called `Directory ID` over there.

The same goes for `TenantName`. The easies way to find this is by navigating to the overview page of your AAD. At the moment it's shown on the top of the page and should be something like `myTenant.onmicrosoft.com`.

The `ClientId` and `ClientSecret` are the values which you have collected when creating the application inside the AAD.

Update the `app.config` file with these settings and you should be good to go!

## Output

When running the application you should be seeing something like the following.

	Alexander 43feae78-da8c-4a14-aca4-b9a67921123f
	Jan de Vries a62d8a6a-db49-4641-99a4-364d672f0a12
	Some other user bda8814a-deaf-4448-86ae-8344da8acc0c
