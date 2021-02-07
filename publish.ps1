Set-Location -Path $PSScriptRoot
$PSDefaultParameterValues['Out-File:Encoding'] = 'utf8'






If(test-path .\output)
{
    Remove-Item .\output -Force -Recurse
}

dotnet publish -c release -o .\output

cd .\output\wwwroot

echo "* binary" > .gitattributes
echo " " > .nojekyll


git config --global user.email yucaizi1984@gmail.com
git config --global user.name ZiYuCai_Automation

git init .
git add .
git commit -m "auto push"

git push --set-upstream https://$env:TOKEN_AUTO_PUSH@github.com/ZiYuCai1984/ZiYuCai1984.github.io.git master:gh-pages -f