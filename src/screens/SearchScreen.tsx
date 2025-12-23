import Header from "@/components/layouts/Header";
import { View, ScrollView, TextInput, Text, StyleSheet } from "react-native";
import { colors } from "@/utils/colors";

export default function SearchScreen() {
  return (
    <View style={styles.container}>
      <Header />

      <ScrollView
        showsVerticalScrollIndicator={false}
        contentContainerStyle={styles.scrollContent}
      >
        <TextInput
          placeholder="Pesquisar..."
          placeholderTextColor={colors.gray[400]}
          style={styles.input}
        />

        {/* Exemplo de resultados fake */}
        <View style={styles.result}>
          <Text style={styles.resultText}>Resultado 1</Text>
        </View>
        <View style={styles.result}>
          <Text style={styles.resultText}>Resultado 2</Text>
        </View>
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
    gap: 16,
  },
  input: {
    backgroundColor: colors.gray[700],
    color: colors.gray[100],
    padding: 12,
    borderRadius: 8,
  },
  result: {
    backgroundColor: colors.gray[600],
    padding: 16,
    borderRadius: 8,
  },
  resultText: {
    color: colors.gray[100],
    fontSize: 16,
  },
});
