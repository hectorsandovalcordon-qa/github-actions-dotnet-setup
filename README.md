# github-actions-dotnet-setup

Template de proyecto .NET con ramas `main` y `dev`, integración continua con GitHub Actions y configuración de pruebas automatizadas.

---

## 🗂️ Estructura de ramas

- **`main`**: Rama de **producción** (solo código estable y probado).
- **`dev`**: Rama de **integración** y **entorno de pruebas** automáticas.

---

## 🚀 Pasos iniciales

1. **Crear un nuevo repositorio en GitHub**.
2. Clonar el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/dotnet-ci-template.git
   cd dotnet-ci-template
   ```
3. Crear la rama `dev`:

   ```bash
   git checkout -b dev
   git push -u origin dev
   ```
## 🔐 Configurar protección de ramas (desde GitHub)

1. Ve a **Settings → Branches → Add rule**.
2. En **Branch name pattern**, escribe `dev` (y repite para `main`).
3. Activar las siguientes opciones para la rama `dev`:
   - ✅ **Require a pull request before merging**: Obliga que cualquier cambio en la rama `dev` pase por un pull request.
   - ✅ **Require status checks to pass before merging**: Asegura que los tests y compilación pasen antes de permitir el merge.
   - ✅ **Require branches to be up to date before merging**: Evita que se haga merge si la rama `dev` no está actualizada con la base.
   - ✅ **Include administrators** (opcional): Aplica las reglas de protección también a los administradores del repositorio.

4. Repite el proceso para la rama `main` con las mismas configuraciones.

---

## ⚙️ GitHub Actions - CI para `dev`

Crea el archivo `.github/workflows/ci.yml` con el siguiente contenido:

```yaml
name: CI - Build & Test

on:
  pull_request:
    branches:
      - dev

jobs:
  build-and-test:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v3

      - uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '7.0.x'

      - run: dotnet restore
      - run: dotnet build --no-restore --configuration Release
      - run: dotnet test --no-build --verbosity normal --logger "trx"

      - name: Upload test results
        if: always()
        uses: actions/upload-artifact@v3
        with:
          name: test-results
          path: '**/TestResults/*.trx'
```
## 🧪 Tests y requisitos

Asegúrate de tener al menos un proyecto de pruebas con uno de los siguientes frameworks:

- **NUnit / XUnit / MSTest**: Frameworks populares para la ejecución de pruebas unitarias.
- **FluentAssertions / Moq**: Herramientas para realizar aserciones avanzadas y crear mocks en tus pruebas.
- **SpecFlow** (opcional): Framework para pruebas BDD (Behavior-Driven Development) si deseas escribir pruebas de una manera más legible y cercana al lenguaje natural.

Es importante tener un enfoque adecuado para la cobertura de pruebas, lo que asegurará que tu código sea confiable y esté libre de errores.

---

## 📦 Próximos pasos

1. **Añadir SonarQube** para análisis estático de código: SonarQube permite detectar bugs, code smells y mejorar la calidad del código mediante análisis estático.
2. **Configurar despliegues automáticos** desde la rama `main`: Automate deployment processes to your environments.
3. **Añadir pruebas de rendimiento** usando **JMeter**: Configura pruebas de carga para garantizar que tu aplicación pueda manejar la cantidad esperada de tráfico.
4. **Documentar flujos de trabajo Git**: Describe los flujos de trabajo de Git en tu equipo, como ramas para features, hotfixes y merge de cambios.

---
