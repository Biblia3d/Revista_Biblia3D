# LEIAME #

Jogo de realidade aumentada usando Vuforia e Unity para jogos bíblicos usando da revista e dos cards

O jovo foi desenvolvido usando o Unity 2018.4.32f1

### Dependencias para desenvolvimento ###

* Unity 2018.4.32f1
* Um smartphone ou um computador com câmera para testar

### Processo para gerar um Google App Bundle

Em função do projeto usar o vuforia na versão 8 o mesmo com
Unity 2018 trouxe um pequeno problema associado ao **Google Play**
que é a exigência de dizer qual a versão arcore compatível conforme mensagem abaixo:

`O código de versão mínima da dependência ARCore com.google.ar.core.min_apk_version não foi encontrado no arquivo AndroidManifest.xml, mas a tag de metadados com.google.ar.core foi especificada.`

Tal informação deve ser introduzida no **AndroidManifest.xml**.
Para esta introdução ser feita é necessário os seguintes
passos:

1. Deve ter instalado o Android Studios
2. No unity deve exportar um projeto do Android Studios
3. O projeto exportado deve ser aberto no Android Studios
4. Após isso vá no arquivo **AndroidManifest.xml** e nele adicione a seguinte meta-data:

```xml
    <meta-data android:name="com.google.ar.core.min_apk_version" android:value="24" />
```

Mais explicações podem ser vistas no seguinte [forum do unity](https://forum.unity.com/threads/vuforia-7-2-20-and-android-submission-arcore-com-google-ar-core-min_apk_version-isnt-in-androidma.538843/)

Com estes passos executados pode ser executado a partir do Android Studios a criação de um APK ou AAB.

# UDP

Em função de alguns problemas que o Google Developer Program
tem retornado, então seguimos para que a aplicação utilize
os recursos do UDP com base em uma implementação, uso de pacote
e plugin.

Mais informações foram obtidas no [forum do unity](https://forum.unity.com/threads/how-do-you-initialize-udp-sandbox-test-mode.956550/)

### Aviso

Este projeto não pode ser atualizado para outra versao do Unity acima da versao
2018.

### Com quem posso falar para tirar duvidas a respeito do codigo? ###

* Cristovao Andrade