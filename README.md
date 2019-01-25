# List To Contact(*.VCF)
This Project convert number list to vcf files (First Names list and Family Names list are optical).

## How to use
### 1. Select Number List
Select a text file with *.txt type be sure they are line-by-line

### 2. Select FirstName List (optical)
Select a text file with *.txt type be sure they are line-by-line

### 3. Select LastName List (optical)
Select a text file with *.txt type be sure they are line-by-line

#### Important: be sure files are match

## How to build

### 1. Clone the repository

#### Option one clone with git
`git clone https://github.com/mhkarimi1383/ListToContact-VCF-.git`

#### Option two using wget and winrar
`wget https://github.com/mhkarimi1383/ListToContact-VCF-/archive/master.zip`
or
`curl https://github.com/mhkarimi1383/ListToContact-VCF-/archive/master.zip`
then extract files to a directory with winrar
and go to that directory with `cd ListToContact-VCF-`

### 2. build-up
`msbuild ListtoContact.sln`
or
Open the `ListtoContact.sln` with Visual Studio

#### you need .NET Framework 4.7.2 for build that  
