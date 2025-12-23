import Header from "@/components/layouts/Header";
import { View, ScrollView, Text, TextInput, TouchableOpacity, StyleSheet } from "react-native";
import { colors } from "@/utils/colors";

export default function EditScreen() {
  return (
    <View style={styles.container}>
      <Header />

      <ScrollView
        showsVerticalScrollIndicator={false}
        contentContainerStyle={styles.scrollContent}
      >
        <Text style={styles.title}>Editar Página</Text>

        <TextInput
          placeholder="Título"
          placeholderTextColor={colors.gray[400]}
          style={styles.input}
        />

        <TextInput
          placeholder="Descrição"
          placeholderTextColor={colors.gray[400]}
          style={[styles.input, styles.textArea]}
          multiline
        />

        <TouchableOpacity style={styles.button} activeOpacity={0.7}>
          <Text style={styles.buttonText}>Salvar</Text>
        </TouchableOpacity>
      </ScrollView>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 32,
  },
  scrollContent: {
    paddingTop: 24,
    paddingBottom: 100,
    paddingHorizontal: 20,
  },
  title: {
    color: colors.gray[100],
    fontSize: 18,
    marginBottom: 12,
  },
  input: {
    backgroundColor: colors.gray[700],
    color: colors.gray[100],
    padding: 12,
    borderRadius: 8,
    marginBottom: 16,
  },
  textArea: {
    height: 100,
    textAlignVertical: "top",
  },
  button: {
    backgroundColor: colors.gray[500],
    padding: 14,
    borderRadius: 8,
    alignItems: "center",
  },
  buttonText: {
    color: colors.gray[100],
    fontSize: 16,
  },
});
