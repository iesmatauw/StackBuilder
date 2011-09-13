How to use XmlFileProcessor
---------------------------
- check that the path of the schema is correctly set in the application config file

- write an xml file that complies with the schema StackBuilderSchema.xsd
An example of input file (XmlFileProcessorInput.xml) is provided under directory Samples

- launch XmlFileProcessor with a valid command line e.g.:
TreeDim.StackBuilder.XmlFileProcessor.exe  /i "k:\Codeplex\StackBuilder\Samples\XmlFileProcessorInput.xml"