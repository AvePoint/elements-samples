# Elements.Client\Api.ElementsCustomersApi

Method | Description
------------- | -------------
[**Connect-Elements**](ElementsConnectApi.md#connect-elements) | Connect to Elements Public API with Client credentials or Client Secret.
[**Disconnect-Elements**](ElementsConnectApi.md#disconnect-elements) | Disconnect from Elements Public API.
[**Get-ElementsCustomer**](ElementsCustomersApi.md#get-elementscustomer) | Use the following PowerShell command to get the general information of the customers that you manage.
[**Get-ElementsCustomerJob**](ElementsCustomersApi.md#get-elementscustomerjob) | Use the following PowerShell command to get the job information of a specific customer that you manage.
[**Get-ElementsCustomerProtected**](ElementsCustomersApi.md#get-elementscustomerprotected) | Use the following PowerShell command to get the protected data information of a specific customer that you manage.
[**Get-ElementsCustomerServices**](ElementsCustomersApi.md#get-elementscustomerservices) | Use the following PowerShell command to get the subscription details of different services for the customers that you manage.
[**Get-ElementsCustomerScanProfile**](ElementsCustomersApi.md#get-elementscustomerscanprofile) | Use the following PowerShell command to get the profiles for the customer that you manage.
[**Get-ElementsCustomerScanProfileDailyNew**](ElementsCustomersApi.md#get-elementscustomerscanprofiledailynew) | Use the following PowerShell command to get the changes summary of the Scan Profile.
[**Get-ElementsCustomerScanProfileDailyNewDetail**](ElementsCustomersApi.md#get-elementscustomerscanprofiledailynewdetail) | Use the following PowerShell command to get the changes objects of the Scan Profile.

<a name="get-elementscustomer"></a>
# **Get-ElementsCustomer**
> ProjectModel Get-ElementsCustomer<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Id] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-OutFile] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Filter] <Hashtable><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JsonFormat] <Boolean><br>

Use the following PowerShell command to get the general information of the customers that you manage. 

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Id** | **String**| The tenant owner ID of the customer. |  [optional]
 **OutFile** | **String**| The location where the exported file will be stored.| [optional]
 **Filter** | **Hashtable**| Configure the odata parameters to filter customer. | [optional]
 **JsonFormat** | **Boolean**| Response in JSON format. | [optional]

Supported Filter: $filter, $select, $top, $skip and other filtering parameters supported by odata
You can add a hashtable value after -Filter, such as @{'$select'='OwnerEmail'}<br>
Unsupported filter: ID

### Example
```powershell
1. Get-ElementsCustomer
2. Get-ElementsCustomer -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb'
3. Get-ElementsCustomer -OutFile 'C:\exportdir\file.csv'
4. Get-ElementsCustomer -Filter @{'$select'='OwnerEmail'}
5. Get-ElementsCustomer -JsonFormat $true
```

[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)

<a name="get-elementscustomerjob"></a>
# **Get-ElementsCustomerJob**
> Get-ElementsCustomerJob<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Id] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JobType] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JobModule] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-OutFile] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Filter] <Hashtable><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JsonFormat] <Boolean><br>

Use the following PowerShell command to get the job information of a specific customer that you manage. 

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Id** | **String**| The tenant owner ID of the customer. | 
 **JobType** | **String**| The service type of the job. |  [optional]
 **JobModule** | **String**| The service module of the job. |  [optional]
 **OutFile** | **String**| The location where the exported file will be stored.| [optional]
 **Filter** | **Hashtable**| Configure the odata parameters to filter customer.| [optional]
 **JsonFormat** | **Boolean**| Response in JSON format. | [optional]

Supported Filter: $filter, $select, $top, $skip and other filtering parameters supported by odata
You can add a hashtable value after -Filter, such as @{'$top'=3}

### Example
```powershell
1. Get-ElementsCustomerJob -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb'
2. Get-ElementsCustomerJob -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -JobType 'Microsoft 365' -JobModule 'Yammer'
3. Get-ElementsCustomerJob -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -OutFile 'C:\exportdir\file.csv'
4. Get-ElementsCustomerJob -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -Filter @{'$top'=3}
5. Get-ElementsCustomerJob -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -JsonFormat $true
```
Supported job module values:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•Microsoft 365: SharePoint Online, Exchange Online, Microsoft 365 Group, OneDrive for Business, Project Online, Exchange Online Public Folders, Microsoft Teams, Microsoft Teams Chat, Yammer, Power BI, Power Automate, or Power Apps<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•Google Workspace: Gmail, Calendar, Contacts, Drive, or Shared Drives<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•Azure: Virtual Machine, Active Directory, Storage, or Admin Portal Setting<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•Dynamics 365: Dynamics Customer Engagement or Dynamics Unified Operations<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•Salesforce: Salesforce<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•DOR: Microsoft 365 Discovery or Google Workspace Discovery<br>
[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)

<a name="get-elementscustomerprotected"></a>
# **Get-ElementsCustomerProtected**
> Get-ElementsCustomerProtected<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Id] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-OutFile] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Filter] <Hashtable><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JsonFormat] <Boolean><br>

Use the following PowerShell command to get the protected data information of a specific customer that you manage.

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Id** | **String**| The tenant owner ID of the customer. | 
 **OutFile** | **String**| The location where the exported file will be stored.| [optional]
 **Filter** | **Hashtable**| Configure the odata parameters to filter customer.| [optional]
 **JsonFormat** | **Boolean**| Response in JSON format. | [optional]

Supported Filter: $filter, $select, $top, $skip and other filtering parameters supported by odata
You can add a hashtable value after -Filter, such as @{'$top'=3}

### Example
```powershell
1. Get-ElementsCustomerProtected -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb'
2. Get-ElementsCustomerProtected -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -OutFile 'C:\exportdir\file.csv'
3. Get-ElementsCustomerProtected -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -Filter @{'$top'=3}
4. Get-ElementsCustomerProtected -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -JsonFormat $true
```

[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)


<a name="get-elementscustomerservices"></a>
# **Get-ElementsCustomerServices**
> Get-ElementsCustomerServices<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Id] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-OutFile] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Filter] <Hashtable><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JsonFormat] <Boolean><br>

Use the following PowerShell command to get the subscription details of different services for the customers that you manage. 

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Id** | **String**| The tenant owner ID of the customer. | [optional]
 **OutFile** | **String**| The location where the exported file will be stored.| [optional]
 **Filter** | **Hashtable**| Configure the odata parameters to filter customer.| [optional]
 **JsonFormat** | **Boolean**| Response in JSON format. | [optional]

Supported Filter: $filter, $select, $top, $skip and other filtering parameters supported by odata
You can add a hashtable value after -Filter, such as @{'$top'=3}<br>
Unsupported filter: ID

### Example
```powershell
1. Get-ElementsCustomerServices
2. Get-ElementsCustomerServices -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb'
3. Get-ElementsCustomerServices -OutFile 'C:\exportdir\file.csv'
4. Get-ElementsCustomerServices -Filter @{'$top'=3}
5. Get-ElementsCustomerServices -JsonFormat $true
```

[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)

<a name="get-elementscustomerscanprofile"></a>
# **Get-ElementsCustomerScanProfile**
> Get-ElementsCustomerScanProfile<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Id] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-ProfileId] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-OutFile] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Filter] <Hashtable><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JsonFormat] <Boolean><br>

Use the following PowerShell command to get the profiles for the customer that you manage.

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Id** | **String**| The tenant owner ID of the customer. |
 **ProfileId**| **String**| The ID of the profile. | [optional]
 **OutFile** | **String**| The location where the exported file will be stored.| [optional]
 **Filter** | **Hashtable**| Configure the odata parameters to filter customer.| [optional]
 **JsonFormat** | **Boolean**| Response in JSON format. | [optional]

Supported Filter: $filter, $select, $top, $skip and other filtering parameters supported by odata
You can add a hashtable value after -Filter, such as @{'$top'=3}<br>
Unsupported filter: Id,ProfileId

### Example
```powershell
1. Get-ElementsCustomerScanProfile -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb'
2. Get-ElementsCustomerScanProfile -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933'
3. Get-ElementsCustomerScanProfile -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -OutFile 'C:\exportdir\file.csv'
4. Get-ElementsCustomerScanProfile -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -Filter @{'$top'=3}
5. Get-ElementsCustomerScanProfile -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -JsonFormat $true
```

[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)

<a name="get-elementscustomerscanprofiledailynew"></a>
# **Get-ElementsCustomerScanProfileDailyNew**
> Get-ElementsCustomerScanProfileDailyNew<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Id] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-ProfileId] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-OutFile] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Filter] <Hashtable><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JsonFormat] <Boolean><br>

Use the following PowerShell command to get the changes summary of the Scan Profile.

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Id** | **String**| The tenant owner ID of the customer. |
 **ProfileId**| **String**| The ID of the profile. |
 **OutFile** | **String**| The location where the exported file will be stored.| [optional]
 **Filter** | **Hashtable**| Configure the odata parameters to filter customer.| [optional]
 **JsonFormat** | **Boolean**| Response in JSON format. | [optional]

Supported Filter: $filter, $select, $skip and other filtering parameters supported by odata
You can add a hashtable value after -Filter, such as @{'$select'='newRegistedContent'}<br>
Unsupported filter: Id,ProfileId

### Example
```powershell
1. Get-ElementsCustomerScanProfileDailyNew -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933'
2. Get-ElementsCustomerScanProfileDailyNew -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933' -OutFile 'C:\exportdir\file.csv'
3. Get-ElementsCustomerScanProfileDailyNew -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933' -Filter @{'$select'='newRegistedContentCount'}
4. Get-ElementsCustomerScanProfileDailyNew -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933' -JsonFormat $true
```

[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)

<a name="get-elementscustomerscanprofiledailynewdetail"></a>
# **Get-ElementsCustomerScanProfileDailyNewDetail**
> Get-ElementsCustomerScanProfileDailyNewDetail<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Id] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-ProfileId] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-OutFile] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Filter] <Hashtable><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-JsonFormat] <Boolean><br>

Use the following PowerShell command to get the changes objects of the Scan Profile.

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Id** | **String**| The tenant owner ID of the customer. |
 **ProfileId**| **String**| The ID of the profile. |
 **OutFile** | **String**| The location where the exported file will be stored.| [optional]
 **Filter** | **Hashtable**| Configure the odata parameters to filter customer.| [optional]
 **JsonFormat** | **Boolean**| Response in JSON format. | [optional]

Supported Filter: $filter, $select, $skip and other filtering parameters supported by odata
You can add a hashtable value after -Filter, such as @{'$select'='newRegistedContent'}<br>
Unsupported filter: Id,ProfileId

### Example
```powershell
1. Get-ElementsCustomerScanProfileDailyNewDetail -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933'
2. Get-ElementsCustomerScanProfileDailyNewDetail -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933' -OutFile 'C:\exportdir\file.csv'
3. Get-ElementsCustomerScanProfileDailyNewDetail -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933' -Filter @{'$select'='newRegistedContent'}
4. Get-ElementsCustomerScanProfileDailyNewDetail -Id '41e33073-5bf1-4e7f-9945-ce6fcc87cebb' -ProfileId '6639364e-6bc2-4d2c-9222-4f256a10a933' -JsonFormat $true
```

[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)