# Knowledgebase-Sync
NuGet package to merge 2 JSON Objects into 3rd JSON Object to be used to update a Microsoft QnA Maker Knowledgebase.

## FEATURES
C# NuGet package based on .NET Framework 4.7.2

## Input Parameters
Accepts 3 parameters.

- The first 2 input parameters are JSON Objects that need to be merged into a 3rd JSON Object to be returned to the caller.
- The 3rd parameter is the name of the Knowledgebase. i.e "QA-bcnocg-905".

## Inputs
PortalDT is a DataTable created from a query run on the Portals database and is in a csv format.

    var portaldt = PortalDT.Get(context);

Knowledgebase is a JSON Object from the QnA Maker Knowledgebase.

    var knowledgebase = Knowledgebase.Get(context);

KnowledgebaseName is a string value and is the name of the QnA Knowledgebase.
    
    var knowledgebasename = KnowledgebaseName.Get(context);

## Output
UpdateKbJson is a JSON Object to be "REST PATCH" to the QnA Maker Knowledgebase.

## Example:
    var JsonObjectUpdateKbOperationDTO = KnowledgebaseUtility.CreateKnowledgebaseUpdate(portaldt, knowledgebase, knowledgebasename);
